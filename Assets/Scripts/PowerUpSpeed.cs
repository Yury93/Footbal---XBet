using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var character = other.GetComponent<StatePlayer>();
            if (character)
            {
                character.SetSpeed(1);
                Destroy(gameObject);
            }
        }
    }
}
