using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TorqueController : MonoBehaviour
{
    [SerializeField] private float speed;
    /// <summary>
    /// Максимальная и минимальная скорость
    /// </summary>
    [SerializeField] private float speedMax, speedMin;
    /// <summary>
    /// Замедлитель
    /// </summary>
    [SerializeField] private float retarder;
    [SerializeField] private bool activeTape;
    [SerializeField] private Pointer pointer;
    public bool ActiveTape => activeTape;
    public delegate void DelegateStop();
    public event DelegateStop OnStopTape;
    private int countSpin;
    public int CountSpin => countSpin;
    private void Start()
    {
        
       speed = Random.Range(speedMin, speedMax);
        activeTape = true;
        print(speed);
    }
    private void Update()
    {
        if (activeTape)
        {
            if (speed > 0)
            {
                speed -= Time.deltaTime * retarder;
            }
            else if (speed <= 0)
            {
                OnStopTape?.Invoke();
                activeTape = false;
            }
            //if (GameManager.Instance.ScoreCount() + 1 <= countSpin)
            //{
            //    SceneManager.LoadScene("Result");
            //}

           
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
        else if (!activeTape)
        {
            speed = 0;
        }
    }
    public void NewPlay()
    {
        print(speed);
        speed = Random.Range(speedMin, speedMax);
        activeTape = true;
        pointer.gameObject.SetActive(true);
    }
    public void SetCount()
    {
        RandomSpeedSet();
        countSpin += 1;
    }
    public void RandomSpeedSet()
    {
        speed = Random.Range(speedMin, speedMax);
    }
}
