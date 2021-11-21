using System.Collections;

using UnityEngine;
using UnityEngine.UI;

namespace F3Lib.UI
{

    [ExecuteInEditMode]
    [DisallowMultipleComponent]
    public class UIBar : MonoBehaviour
    {
        [SerializeField] private GameObject _background = null;
        [SerializeField] private GameObject _filler = null;
        [SerializeField] private Text _currentValue = null;
        [SerializeField] [Range(0f, 1f)] private float _fillAmount;

        private Image _fillerImage = null;

        public FloatEvent fillAmountChange = new FloatEvent();
        public float FillAmount
        {
            get => _fillAmount;
            set
            {
                if (value >= 0f && value <= 1f)
                {
                    _fillAmount = value;
                    StopAllCoroutines();
                    StartCoroutine(nameof(ChangeFillAmount));
                }
            }
        }

        public void SetValue(float maxValue)
        {
            if (_currentValue == null) return;
            float currentValue = maxValue * _fillAmount;
            _currentValue.text = currentValue + "/" + maxValue;
        }

        private void Update()
        {
            if (Application.isPlaying == false) RunInEditMode();
        }

        private void RunInEditMode() => _fillerImage.fillAmount = _fillAmount;


        private void OnEnable() => Requiares();

        private void OnDisable() => StopAllCoroutines();

        private void Requiares()
        {
            if (_background == null || _filler == null) enabled = false;

            if (_filler.TryGetComponent(out _fillerImage))
            {
                _fillerImage.type = Image.Type.Filled;
                _fillerImage.fillMethod = Image.FillMethod.Horizontal;
            }
            else
            {
                _fillerImage = _filler.AddComponent<Image>();
                _fillerImage.type = Image.Type.Filled;
                _fillerImage.fillMethod = Image.FillMethod.Horizontal;
            }
        }

        private IEnumerator ChangeFillAmount()
        {
            if (_fillerImage == null) _filler.TryGetComponent(out _fillerImage);

            float oldValue = _fillerImage.fillAmount;
            float expirationTime = 0;

            while (_fillerImage.fillAmount != _fillAmount)
            {
                _fillerImage.fillAmount = Mathf.Lerp(oldValue, _fillAmount, expirationTime);
                fillAmountChange?.Invoke(_fillerImage.fillAmount);
                expirationTime += Time.deltaTime * 1.25f;
                yield return null;
            }

        }
    }
}