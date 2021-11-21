using UnityEngine;

namespace F3Lib.UI
{
    [RequireComponent(typeof(ParticleSystem), typeof(RectTransform))]
    [DisallowMultipleComponent]
    public class FillerParticles : MonoBehaviour
    {
        [SerializeField] private RectTransform _minPoint = null;
        [SerializeField] private RectTransform _maxPoint = null;

        private ParticleSystem _particles;
        private RectTransform _rect;
        private RectTransform _parent;
        private Vector3 _minPointPosition;
        private Vector3 _maxPointPosition;

        private void OnEnable()
        {
            _particles = GetComponent<ParticleSystem>();
            _rect = GetComponent<RectTransform>();
            _parent = GetComponentInParent<RectTransform>();
            _minPointPosition = _minPoint.localPosition;
            _maxPointPosition = _maxPoint.localPosition;
        }

        public void Play(float value)
        {
            if (_rect == null || _particles == null) return;

            Vector3 lerpPos = Vector3.Lerp(_minPointPosition, _maxPointPosition, value);
            _rect.localPosition = lerpPos;
            _particles.Play();
        }
    }
}