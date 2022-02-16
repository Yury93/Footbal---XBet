using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : SingletonBase<ScoreText>
{
    [SerializeField] private Text redScore, blueScore;
    private void Start()
    {
        blueScore.text = (PlayerPrefs.GetInt("ScoreCount")).ToString();
        redScore.text = 0.ToString();
    }
    public void UpdateScore(int redGoal)
    {
        redScore.text = redGoal.ToString();
    }
}
