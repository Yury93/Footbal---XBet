using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private StatePlayer stateController;
    private void Start()
    {
        animator = GetComponent<Animator>();
        stateController = GetComponent<StatePlayer>();
        //stateController.OnKickAI += StateController_OnKickAI;
    }

    public void StateController_OnKickAI()
    {
        animator.SetTrigger("AIKick");
        Destroy(gameObject, 1.5f);
    }
}
