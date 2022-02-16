using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : SingletonBase<GameManager>
{
    [SerializeField] private Text timerText,scoreText;
    [SerializeField] private float timer;
    [SerializeField] private int score, scoreCount;
    [SerializeField] private GameObject particalGoal;
    private void Start()
    {
        timerText.text = "Timer: " + (Convert.ToInt32(timer)).ToString();
        score = 0;
        scoreCount = 0;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("ScoreCount", score);

    }
    private void FixedUpdate()
    {
        timer -= Time.fixedDeltaTime;
        timerText.text = "Timer: " + (Convert.ToInt32(timer)).ToString();
        if(timer <= 0 )
        {
            SceneManager.LoadScene("SceneGoalkeeper");
        }
     
    }
    public void AddTime(int time)
    {
        timer += time;
    }
    public int ScoreCount()
    {
        scoreCount = PlayerPrefs.GetInt("ScoreCount");
        return scoreCount;
    }
    public void AddScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text =  score.ToString();
        PlayerPrefs.SetInt("ScoreCount", score);
    }
    public void CreateParticle(Vector3 pos)
    {
        var go = Instantiate(particalGoal, pos, Quaternion.identity);
        Destroy(go, 2);
    }
}
