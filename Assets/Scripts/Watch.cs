using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watch : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.AddTime(10);
            Destroy(gameObject);
        }
    }
}
