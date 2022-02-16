using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    [SerializeField] private StatePlayer statePlayer;

    private void Update()
    {

        if(Input.GetMouseButton(0))
        {
            statePlayer.SetMode("move");
        }
    }
}
