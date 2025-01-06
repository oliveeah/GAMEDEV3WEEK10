using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    
    public int score;
    public float timeLeft = 60f;
    public int[] packageValues = new int[] { 12345, -5434};
    public int successRate;
    public int lives = 5;
    public float playTime = 0;

    [SerializeField] GameEvent restartGame;
    [SerializeField] GameEvent gameOver;




    protected override void Awake()
    {
        base.Awake();
        Initialisation();
    }
    
    // Update is called once per frame
    void Update()
    {
        ValuesClamping();
        TimeGoingDown();
        if (SceneManager.GetActiveScene().name == ("scn_Level1"))
        {
            StartCounting();
        }
        else if(SceneManager.GetActiveScene().name == ("scn_GameOver") && Input.anyKeyDown)
        {
            restartGame.Raise();
        }
    }

    

    private void Initialisation()
    {
        playTime = 0f;
        score = 0;
        successRate = 0;
    }

    private void TimeGoingDown()
    {
        if (SceneManager.GetActiveScene().name == ("scn_MainMenu"))
        {
            return;
        }
        else if (SceneManager.GetActiveScene().name == ("scn_GameOver"))
        {
            return;
        }
        else
        {
            timeLeft -= Time.deltaTime;
        }
              
    }

    private void ValuesClamping()
    {
        score = Mathf.Clamp(score, 0, 100000000);
        successRate = Mathf.Clamp(successRate, 0, 100);
        timeLeft = Mathf.Clamp(timeLeft, 0, 120);
        lives = Mathf.Clamp(lives, 0, 10);
    }

    private void StartCounting()
    {
        playTime += Time.deltaTime;
    }

    public void GreenPackLogic()
    {
        score += packageValues[0];
        successRate++;
    }
    public void RedPackLogic()
    {
        //To tweak the score
        if (score >= 543)
        {
            score += packageValues[1];
        }
        else
        {
            score = 0;
        }
        successRate -= 3;
        lives--;   
        if (lives <= 0)
        {
            gameOver.Raise();
        }
    }

    public void RestartGame()
    {
        score = 0;
        successRate = 0;
        lives = 5;
        playTime = 0f;
    }
}
