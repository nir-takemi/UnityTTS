
using UnityEngine;
using UnityEngine.UI;

namespace ylib.Services
{
    /// <summary>
    /// 最小構成のサンプル呼び出し
    /// </summary>
    sealed class SampleScene : MonoBehaviour
    {
        [SerializeField]
        private Button btnPlay = default;
        [SerializeField]
        private InputField inptText = default;

        [SerializeField]
        private Slider sldrVolume = default;
        [SerializeField]
        private Slider sldrRate = default;
        [SerializeField]
        private Slider sldrPitch = default;

        public void Start()
        {
            btnPlay.onClick.AddListener(() =>
            {
                ylib.Services.UnityTTS.Speech(inptText.text);
            });

            sldrVolume.value = ylib.Services.UnityTTS.Volume;
            sldrVolume.onValueChanged.AddListener((value) =>
            {
                ylib.Services.UnityTTS.Volume = value;
            });
            sldrRate.value = ylib.Services.UnityTTS.Rate;
            sldrRate.onValueChanged.AddListener((value) =>
            {
                ylib.Services.UnityTTS.Rate = value;
            });
            sldrPitch.value = ylib.Services.UnityTTS.Pitch;
            sldrPitch.onValueChanged.AddListener((value) =>
            {
                ylib.Services.UnityTTS.Pitch = value;
            });

            // テキトーにデフォルト値をセット
            inptText.text = "Hello! I'm Emily. I am very tired.";
        }
    }
}