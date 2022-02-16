using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateTape : MonoBehaviour
{
    [SerializeField] private GoalkeeperMovement goalkeeper;
    [SerializeField] private TorqueController torqueController;
    [SerializeField] private TapeManager tapeManager;
    [SerializeField] private int goal;
    public int Goal => goal;
    private void Start()
    {
        goal = 0;
        PlayerPrefs.SetInt("GoalRed", goal);
    }
    private void OnTriggerEnter(Collider other)
    {
        var ball = other.gameObject.GetComponent<BallKick>();
        if (ball)
        {
            tapeManager.CreateParticleGoal(ball.transform.position);
            ball.GetComponent<AudioSource>().Play();
            goal += 1;
            PlayerPrefs.SetInt("GoalRed", goal);
            ScoreText.Instance.UpdateScore(goal);
            torqueController.SetCount();

            StartCoroutine(CorStartPosBall());

            IEnumerator CorStartPosBall()
            {
                yield return new WaitForSeconds(1);
                ball.GetComponent<MeshRenderer>().enabled = false;
                ball.RB.drag = 2000000F;
                ball.RB.angularDrag = 20000000F;

                ball.transform.position = ball.StartPos;

                if (GameManager.Instance.ScoreCount() + 1 <= torqueController.CountSpin )
                {
                    Time.timeScale = 1;
                    SceneManager.LoadScene("Result");
                }

                yield return new WaitForSeconds(2f);
                ball.GetComponent<MeshRenderer>().enabled = true;
                ball.RB.drag = 0F;
                ball.RB.angularDrag = 0.05F;

                goalkeeper.transform.DOLocalMoveX(0, 1 - 0.5F);
                yield return new WaitForSeconds(1);

                //TapeManager.Instance.TapeActiveGo();
            }
        }
    }
}
