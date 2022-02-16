using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private int scoreBlue, scoreRed;
    [SerializeField] private Text scoreBlueTxt, scoreRedTxt;

    private void Start()
    {
        scoreRed = PlayerPrefs.GetInt("GoalRed");
        scoreBlue = PlayerPrefs.GetInt("ScoreCount");
        scoreBlueTxt.text = scoreBlue.ToString();
        scoreRedTxt.text = scoreRed.ToString();

        if(scoreBlue > scoreRed)
        {
            StartCoroutine(CorWin());
        }
        if(scoreBlue < scoreRed)
        {
            StartCoroutine(CorLose());
        }
        if(scoreBlue == scoreRed)
        {
            StartCoroutine(CorDraw());
        }
    }
    IEnumerator CorWin()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("WinScene");
    }
    IEnumerator CorDraw()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("DrawScene");
    }
    IEnumerator CorLose()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("LoseScene");
    }
}
