using UnityEngine;

namespace SoundSystem
{
    public class Sound : ISound
    {
        public void Play(AudioSource source)
        {
            source.Play();
        }

        public void Stop(AudioSource source)
        {
            source.Stop();
        }
    }
}