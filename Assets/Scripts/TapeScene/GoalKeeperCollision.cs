using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalKeeperCollision : MonoBehaviour
{
    [SerializeField] private TorqueController torqueController;
    private void OnCollisionEnter(Collision collision)
    {
        var ball = collision.gameObject.GetComponent<BallKick>();
        if (ball)
        {
            ball.GetComponent<MeshRenderer>().enabled = false;
            ball.RB.drag = 2000000F;
            ball.RB.angularDrag = 20000000F;
            
            ball.transform.position = ball.StartPos;

            StartCoroutine(CorStartPosBall());

            IEnumerator CorStartPosBall()
            {
                yield return new WaitForSeconds(0);
                torqueController.SetCount();

                if (GameManager.Instance.ScoreCount() + 1 <= torqueController.CountSpin)
                {
                    SceneManager.LoadScene("Result");
                }
                torqueController.RandomSpeedSet();
                yield return new WaitForSeconds(2f);
                ball.GetComponent<MeshRenderer>().enabled = true;
                ball.RB.drag = 0F;
                ball.RB.angularDrag = 0.05F;
                //TapeManager.Instance.TapeActiveGo();
                //gameObject.GetComponent<GoalkeeperMovement>().MoveGoalkeeperCentr();
                
            }
        }
    }
}
