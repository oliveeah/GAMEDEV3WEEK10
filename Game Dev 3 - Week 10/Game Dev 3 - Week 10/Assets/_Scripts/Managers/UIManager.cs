using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace GameDevWithMarco.Managers
{

    public class UIManager : MonoBehaviour
    {
        //Objects
        public Text countdownText;
        public TextMeshProUGUI scoreTextBox;
        public TextMeshProUGUI livesTextBox;
        public Text timeTextBox;
        public GameObject minusOneLifePosition;
        public GameObject minusOneLife;
        public GameObject plusOneLife;
        //Variables
        public string testString = "Test String";
        private Text gameOverScore;
        private Text gameOverScoreComment;

        private Dictionary<int, string> scoreComments = new Dictionary<int, string>
    {
        { 0, "HUMAN, TRY AGAIN" },
        { 20000, "LOW SKILL DETECTED" },
        { 50000, "MINIMUM TARGET ACHIEVED" },
        { 100000, "ASCENSION LEVEL NOT ACHIEVED" },
        { 300000, "KEEP PLAYING PUNY HUMAN" },
        { 600000, "NOT QUITE MY TEMPO" },
        { 1000000, "ASCENSION LEVEL ACHIEVED, I WAS JOKING KEEP GOING" },
        { 2000000, "WELL DONE, HUMAN" },
        { 3000000, "SHOW THIS SCORE TO YOUR MOM" },
        { 4000000, "YOU ARE A PROFESSIONAL NOW" },
        { 5000000, "CHALLENGE SOMEONE TO BEAT YOUR SCORE" },
        { 6000000, "YOU HAVE ASCENDED, SEND ME YOUR SCORE HUMAN - TWITTER @iS_m4v" }
    };


        private void Awake()
        {
            Initialisation();
        }



        void Update()
        {
            ScoreAndTimerUpdater();
            ChangeTimerColor();
        }

        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (SceneManager.GetActiveScene().name == "scn_GameOver")
            {
                GameOverInitialisation();
            }
        }

        public void ScoreAndTimerUpdater()
        {

            if (scoreTextBox != null)
            {
                scoreTextBox.text = "SCORE:" + GameManager.Instance.score.ToString();
            }
            if (livesTextBox != null)
            {
                livesTextBox.text = "LIVES: " + GameManager.Instance.lives.ToString("f0");
            }
            if (timeTextBox != null)
            {
                timeTextBox.text = "TIME: " + GameManager.Instance.playTime.ToString("f0");
            }

        }

        private void ChangeTimerColor()
        {
            if (livesTextBox != null)
            {
                if (GameManager.Instance.lives < 2)
                {
                    livesTextBox.color = new Color(1, 0, 0);
                }
            }

        }




        private void FinalComment()
        {
            if (gameOverScoreComment == null)
                return; // Code Blocker

            foreach (var scoreThreshold in scoreComments.Keys)
            {
                if (GameManager.Instance.score < scoreThreshold)
                {
                    gameOverScoreComment.text = scoreComments[scoreThreshold] + " - RESTART SESSION";
                    return;
                }
            }
        }

        public void MinusOneLifeFeedback()
        {
            var minusFeedback = Instantiate(minusOneLife, minusOneLifePosition.transform.position, Quaternion.identity) as GameObject;
            minusFeedback.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            minusFeedback.transform.position = minusOneLifePosition.transform.position;
            Destroy(minusFeedback, 2f);

        }

        public void PlusOneLifeFeedback()
        {
            var plusFeedback = Instantiate(plusOneLife, minusOneLifePosition.transform.position, Quaternion.identity) as GameObject;
            plusFeedback.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
            plusFeedback.transform.position = minusOneLifePosition.transform.position;
            Destroy(plusFeedback, 2f);
        }


        private void Initialisation()
        {
            scoreTextBox = GameObject.Find("txtPro_Score").GetComponent<TextMeshProUGUI>();
            scoreTextBox.text = "SCORE:" + GameManager.Instance.score.ToString();

            livesTextBox = GameObject.Find("txtPro_Lives").GetComponent<TextMeshProUGUI>();
            livesTextBox.text = "LIVES: " + GameManager.Instance.lives.ToString("f0");

            timeTextBox = GameObject.Find("txt_Timer").GetComponent<Text>();

        }

        private void GameOverInitialisation()
        {
            gameOverScore = GameObject.Find("txt_TotalScore").GetComponent<Text>();
            gameOverScore.text = "THE TOTAL SCORE IS " + GameManager.Instance.score + " AND YOU SURVIVED " + GameManager.Instance.playTime.ToString("f2") + " seconds!"; ;
            gameOverScoreComment = GameObject.Find("txt_TotalScoreComment").GetComponent<Text>();
            FinalComment();
        }
    }

}