using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    /// <summary>
    /// Длина уровня
    /// </summary>
    private float lengthLvlZ, lengthLvlX;

    [SerializeField] private Register register;
    [SerializeField] private GameObject ground;
    private int index;
    [SerializeField] private SpawnerBall spawner;
    [SerializeField] private float timerDestroy;
    [SerializeField] private GameObject particalCreateLevel;

    void Start()
    {
        particalCreateLevel.GetComponent<ParticleSystem>().Play();
        var bounds = GetComponent<Collider>().bounds;
        lengthLvlZ = bounds.size.z;
        lengthLvlX = bounds.size.x*2;

        if(register)
        register.OnReg += GenerateActiveted;

        spawner = GetComponentInChildren<SpawnerBall>();
        if (spawner)
        {
            spawner.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        StartCoroutine(CorDestroyer());
        IEnumerator CorDestroyer()
        {
            //yield return new WaitForSeconds(2f);
            //partical.Play();
            yield return new WaitForSeconds(timerDestroy);
            Destroy(gameObject);
        }
    }

    public void GenerateActiveted()
    {
        index = Random.Range(0, 2);

        if (index == 0)
        {
            Vector3 placeGenertionZ = new Vector3(transform.position.x, transform.position.y, transform.position.z + lengthLvlZ);
            ground = Instantiate(ground, placeGenertionZ, Quaternion.identity);
            
        }
        if (index == 1)
        {
            Vector3 placeGenertionX = new Vector3(transform.position.x + lengthLvlX/2 , transform.position.y, transform.position.z);
            ground = Instantiate(ground, placeGenertionX, Quaternion.Euler(0,90,0));
           
        }
    }
}
