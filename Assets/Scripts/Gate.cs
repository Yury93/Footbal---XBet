using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        var ball = other.GetComponent<MovementBall>();
        if(ball)
        {
            ball.GetComponent<AudioSource>().Play();
            GetComponentInParent<Animator>().Play("@GoalGate");
            StartCoroutine(corDestroyBall());
            IEnumerator corDestroyBall()
            {
                yield return new WaitForSeconds(0.5f);
                GameManager.Instance.CreateParticle(ball.transform.position + Vector3.up / 3);
                Destroy(other.gameObject);
            }
          
            //Destroy(gameObject, 1f);
            gameObject.GetComponent<BoxCollider>().enabled = false;

            GameManager.Instance.AddScore(1);
        }
    }
}
