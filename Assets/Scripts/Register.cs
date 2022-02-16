using System.Collections;
using UnityEngine;

public class Register : MonoBehaviour
{
    public delegate void DelegateRegister();
    public event DelegateRegister OnReg;

    public int index;
    [SerializeField] private GameObject goParent;
    [SerializeField] private float timerDestroy;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            OnReg?.Invoke();
        }
    }
}
