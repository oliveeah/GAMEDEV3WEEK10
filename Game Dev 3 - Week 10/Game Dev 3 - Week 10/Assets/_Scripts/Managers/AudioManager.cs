using GameDevWithMarco.DataSO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevWithMarco.Managers
{
    public class AudioManager : Singleton<AudioManager>
    {
        /// <summary>
        /// This script will drive anything related to Audio
        /// </summary>

        [SerializeField] AudioClip backgroundMusic;
        [SerializeField] SoundSO goodPickupSound;
        [SerializeField] SoundSO badPickupSound;
        [SerializeField] SoundSO dashSound;
        [SerializeField] SoundSO lifeSound;
        [SerializeField] AudioSource audioSource_Music;
        [SerializeField] AudioSource audioSource_Sounds;

        // Start is called before the first frame update
        void Start()
        {
            if (backgroundMusic != null)
            {
                PlayBackgroundMusic();
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (backgroundMusic != null)
            {
                audioSource_Music.volume += 0.1f * Time.deltaTime;
                if (audioSource_Music.volume >= 0.2f)
                {
                    audioSource_Music.volume = 0.2f;
                }
            }
        }

        private void PlaySound(float lowPitcHRange, float highPitcHRange, AudioClip clipToPlay, float volume)
        {
            audioSource_Sounds.pitch = Random.Range(lowPitcHRange, highPitcHRange);
            audioSource_Sounds.PlayOneShot(clipToPlay);
            audioSource_Sounds.volume = volume;
        }


        public void GoodPickupSound()
        {
            PlaySound(goodPickupSound.minPitchValue, goodPickupSound.maxPitchValue,
                        goodPickupSound.clipToUse, goodPickupSound.soundVolume);
        }
        public void BadPickupSound()
        {
            PlaySound(badPickupSound.minPitchValue, badPickupSound.maxPitchValue,
                        badPickupSound.clipToUse, badPickupSound.soundVolume);
        }
        public void PlayBackgroundMusic()
        {

            audioSource_Music.volume = 0f;
            audioSource_Music.clip = backgroundMusic;
            audioSource_Music.Play();
            audioSource_Music.loop = true;
        }
        public void Dash()
        {
            PlaySound(dashSound.minPitchValue, dashSound.maxPitchValue,
                        dashSound.clipToUse, dashSound.soundVolume);
        }
        public void LifePickupSound()
        {
            PlaySound(lifeSound.minPitchValue, lifeSound.maxPitchValue,
                         lifeSound.clipToUse, lifeSound.soundVolume);

        }
    }
}


