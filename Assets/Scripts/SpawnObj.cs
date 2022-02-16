using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private int countObj;
    [SerializeField] private float radius;

    [SerializeField] private bool random = false;

    [SerializeField] private int minCount, maxCount;
    private void Start()
    {
        StartCoroutine(CorSpawn());
        IEnumerator CorSpawn()
        {
            yield return new WaitForSeconds(1f);
            if (random)
            {
                countObj = Random.Range(minCount, maxCount);
            }
            for (int i = 0; i < countObj; i++)
            {
                yield return new WaitForSeconds(0.2f);
                Instantiate(obj, transform.position +
                    new Vector3(Random.insideUnitSphere.x * radius, 0, Random.insideUnitSphere.z * radius),
                    Quaternion.identity);
            }
        }
    }
}
