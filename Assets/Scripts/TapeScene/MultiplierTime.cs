using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierTime : MonoBehaviour
{
    public void TimePlus()
    {
        if (Time.timeScale < 20)
        {
            Time.timeScale *= 3;
        }
    }
    public void TimeReset()
    {
        Time.timeScale = 1;
    }
}
