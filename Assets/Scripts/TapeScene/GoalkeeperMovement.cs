using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoalkeeperMovement : MonoBehaviour
{
    [SerializeField] private float moveX;
    [SerializeField] private float time;
    //private Rigidbody rb;
    //private int randomSelect;

    public static event Action OnActiveTape;
    public void MovingToBallRandom()
    {
        //randomSelect = Random.Range(0, 3);
       
        //if (randomSelect == 0)
        //{
        //    MoveGoalkeeperCentr();
        //}
        //if (randomSelect == 1)
        //{
        //    MoveGoalkeeperLeft();
        //}
        //if (randomSelect == 2)
        //{
        //    MoveGoalkeeperRight();
        //}
    }
  
    public void MoveGoalkeeperRight()
    {
        transform.DOLocalMoveY(15.65F, time - 0.5F);
        transform.DOLocalMoveZ(0, time - 0.5F);
        MoveGoalkeeper(moveX, time);
        OnActiveTape?.Invoke();
    }
    public void MoveGoalkeeperLeft()
    {
        transform.DOLocalMoveY(15.65F, time - 0.5F);
        transform.DOLocalMoveZ(0, time - 0.5F);
        MoveGoalkeeper(-moveX, time);
        OnActiveTape?.Invoke();
    }
    public void MoveGoalkeeperCentr()
    {
        transform.DOLocalMoveX(0, time - 0.5F);
        transform.DOLocalMoveZ(0, time - 0.5F);
        transform.DOLocalMoveY(14.8F, time - 0.5F);
        OnActiveTape?.Invoke();
    }
   

    public void MoveGoalkeeper(float move, float timer)
    {
        transform.DOLocalMoveX(move, timer);
    }
}
