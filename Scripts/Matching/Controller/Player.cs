using TMPro;
using UnityEngine;

namespace Matching.Controller
{
    public class Player : MonoBehaviour
    {
        private delegate void OnClick();
        private OnClick _onClick;

        private new AudioSource _audio;
        private TMP_Text _pointText;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            _pointText = GameObject.Find("Score").GetComponent<TMP_Text>();
        }

        private void OnEnable()
        {
            _onClick += PlaySound;
            _onClick += IncreasePoint;
        }

        private void OnDisable()
        {
            _onClick -= PlaySound;
            _onClick -= IncreasePoint;
        }

        private void PlaySound()
        {
            _audio.Play();
        }

        private void IncreasePoint()
        {
            _pointText.text = (int.Parse(_pointText.text) + 1).ToString();
        }

        public void OnClickOccur()
        {
            _onClick();
        }
    }
}
