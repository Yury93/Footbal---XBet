using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBallTape : MonoBehaviour
{
    [SerializeField] private GameObject prefabBall;
    void Start()
    {
        Instantiate(prefabBall, transform.position, Quaternion.identity);
    }
}
