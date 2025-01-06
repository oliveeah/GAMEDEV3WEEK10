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
        [SerializeField] AudioClip goodPickupSound;
        [SerializeField] AudioClip badPickupSound;
        [SerializeField] AudioClip dashSound;
        [SerializeField] AudioClip lifeSound;
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


        public void GoodPickupSound()
        {
            audioSource_Sounds.pitch = Random.Range(0.9f, 1.1f);
            audioSource_Sounds.PlayOneShot(goodPickupSound);
            audioSource_Sounds.volume = 2f;
        }
        public void BadPickupSound()
        {
            audioSource_Sounds.pitch = Random.Range(0.9f, 1.1f);
            audioSource_Sounds.PlayOneShot(badPickupSound);
            audioSource_Sounds.volume = 0.4f;
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
            audioSource_Sounds.pitch = Random.Range(0.7f, 1f);
            audioSource_Sounds.PlayOneShot(dashSound);
            audioSource_Sounds.volume = 0.1f;
        }
        public void LifePickupSound()
        {
            audioSource_Sounds.pitch = Random.Range(0.9f, 1.1f);
            audioSource_Sounds.PlayOneShot(lifeSound);
            audioSource_Sounds.volume = 1f;
        }
    }
}


