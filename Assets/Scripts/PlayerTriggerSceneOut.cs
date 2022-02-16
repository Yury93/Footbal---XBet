using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTriggerSceneOut : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (transform.position.y < -50)
        {
            SceneManager.LoadScene("SceneGoalkeeper");
            print("игрок нижу уровня");
        }
    }
}
