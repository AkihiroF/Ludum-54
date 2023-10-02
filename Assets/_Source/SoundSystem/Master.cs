using UnityEngine;
using UnityEngine.Audio;

namespace SoundSystem
{
    public class Master : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;

        private const string SOUND_NAME = "Sound";

        private void Start()
        {
            mixer.SetFloat(SOUND_NAME, PlayerPrefs.HasKey(SOUND_NAME) ? PlayerPrefs.GetFloat(SOUND_NAME) : 0);
            PlayerPrefs.Save();
        }

        public void ChangeSound(float value)
        {
            mixer.SetFloat(SOUND_NAME, value);
            PlayerPrefs.SetFloat(SOUND_NAME, value);
            PlayerPrefs.Save();
        }
    }
}