using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Kino;

namespace GameDevWithMarco.Managers
{

    public class VfxManager : MonoBehaviour
    {

        [Header("ScreenShake")]
        public Animator camAnim;
        [Header("Particles")]
        public GameObject goodPickupParticles;
        public GameObject badPickupParticles;
        public Transform particleSpawnerPos;
        [Header("PlayerFeedback")]
        public GameObject subtractPointsPrompt;
        public GameObject addPointsPrompt;
        public Transform subtractPointsPromptPosition;
        public Transform addPointsPromptPosition;
        [Header("GlitchEffect")]
        public DigitalGlitch glitch;
        [SerializeField] float glitchEnd = 0.95f;
        [SerializeField] float glitchStageFour = 0.16f;
        [SerializeField] float glitchStageThree = 0.12f;
        [SerializeField] float glitchStageTwo = 0.08f;
        [SerializeField] float glitchStageOne = 0.04f;
        [SerializeField] float glitchZero = 0f;
        [SerializeField] float gameOverGlitchDelay = 0f;

        private void Awake()
        {
            if (SceneManager.GetActiveScene().name == "scn_GameOver")
            {
                GameOverSceneEffects();
                gameOverGlitchDelay = Mathf.Clamp(gameOverGlitchDelay, 0, 1);

            }
        }
        private void Update()
        {

            if (SceneManager.GetActiveScene().name == "scn_Level1")
            {
                GlitchWhenFailing();

            }
            if (SceneManager.GetActiveScene().name == "scn_GameOver")
            {
                gameOverGlitchDelay += 0.05f * Time.deltaTime;
                glitch.intensity -= gameOverGlitchDelay;
                if (glitch.intensity <= glitchStageOne)
                {
                    glitch.intensity = glitchStageOne;
                }
            }
        }
        public void CamShake()
        {
            camAnim.SetTrigger("shake");
        }
        public void GoodPickupParticles()
        {
            var goodExplosion = Instantiate(goodPickupParticles, particleSpawnerPos.position, Quaternion.identity) as GameObject;
            Destroy(goodExplosion, 0.8f);
        }
        public void BadPickupParticles()
        {
            var badExplosion = Instantiate(badPickupParticles, particleSpawnerPos.position, Quaternion.identity) as GameObject;
            Destroy(badExplosion, 0.8f);
        }
        public void AddPointsPromptMethod()
        {
            var addPoints = Instantiate(addPointsPrompt, addPointsPromptPosition.position, Quaternion.identity) as GameObject;
            addPoints.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            addPoints.transform.position = addPointsPromptPosition.position;
            Destroy(addPoints, 0.8f);
        }
        public void SubtractPointsPromptMethod()
        {
            var subtractPoints = Instantiate(this.subtractPointsPrompt, subtractPointsPromptPosition.position, Quaternion.identity) as GameObject;
            subtractPoints.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            subtractPoints.transform.position = subtractPointsPromptPosition.position;
            Destroy(subtractPoints, 0.8f);
        }
        public void GlitchWhenFailing()
        {
            switch (GameManager.Instance.lives)
            {
                case 5: glitch.intensity = glitchZero; break;
                case 4: glitch.intensity = Mathf.Lerp(glitchZero, glitchStageOne, 1); break;
                case 3: glitch.intensity = Mathf.Lerp(glitchStageOne, glitchStageTwo, 1); break;
                case 2: glitch.intensity = Mathf.Lerp(glitchStageTwo, glitchStageThree, 1); break;
                case 1: glitch.intensity = Mathf.Lerp(glitchStageThree, glitchStageFour, 1); break;
                case 0: glitch.intensity = Mathf.Lerp(glitchStageFour, glitchEnd, 0.2f); break;
            }
        }
        private void GameOverSceneEffects()
        {
            glitch.intensity = glitchEnd;
        }
    }

}