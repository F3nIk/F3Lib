using F3Lib.Variables;
using UnityEngine;

namespace F3Lib.Android
{

    public class Vibrator : MonoBehaviour
    {
        [SerializeField] private BoolReference _muted = new BoolReference(false);
        public void Vibrate()
        {
            if (_muted.Value == false) return;

            Vibration.Vibrate();
        }

        public void Vibrate(int duration)
        {
            if (_muted.Value == false) return;

            Vibration.Vibrate(duration);
        }
    }
}