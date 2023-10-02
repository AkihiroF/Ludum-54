using UnityEngine;

namespace SoundSystem
{
    public interface ISound
    {
        void Play(AudioSource source);
        void Stop(AudioSource source);
    }
}