using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBall : MonoBehaviour
{
    [SerializeField] private GameObject prefabNewBall;
    private int countBall = 0;
    [SerializeField] private float time;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(CorSpawn());
            IEnumerator CorSpawn()
            {
                yield return new WaitForSeconds(time);
                countBall = Random.Range(1, 3);
                for (int i = 0; i < countBall; i++)
                {
                    var go = Instantiate(prefabNewBall, other.transform.position + Vector3.forward , Quaternion.identity);
                    go.GetComponent<MovementBall>().SetPlayer(other.gameObject);

                    if (i <= countBall)
                    {
                        gameObject.GetComponent<BoxCollider>().enabled = false;
                    }
                }
            }
        }
    }
}

