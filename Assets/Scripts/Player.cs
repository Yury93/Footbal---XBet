using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private GameObject primitive;
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        //if (transform.position.y < -50)
        //{
        //    SceneManager.LoadScene("SceneGoalkeeper");
        //    print("игрок нижу уровня");
        //}
        
       
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var ball = hit.gameObject.GetComponent<MovementBall>();
        if (ball)
        {
            ball.SetPlayer(gameObject);
        }
    }
}
