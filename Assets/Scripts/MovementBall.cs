using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBall : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float distance;
    private Rigidbody rb;
    private GameObject player;
    private StatePlayer statePlayer;
    private Vector3 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (player && statePlayer.GetMode == StatePlayer.Mode.move)
        {
            Vector3 movement = Vector3.Lerp(transform.position, direction, distance);
            rb.AddForce(movement * speed * Time.deltaTime, ForceMode.Impulse);
        }
    }
    private void FixedUpdate()
    {
        if (player && statePlayer.GetMode == StatePlayer.Mode.move)
        {
            direction = player.transform.position + Vector3.forward/4 - transform.position;
            if (direction.magnitude > 1)
            {
                distance = 1;
            }
            else
            {
                distance = 0;
            }
        }
    }
    private void OnDestroy()
    {
        
        if (statePlayer)
        {
            statePlayer.SetMode("move");
        }
    }
    public void SetPlayer(GameObject newPlayer)
    {
        player = newPlayer;
        statePlayer = newPlayer.GetComponent<StatePlayer>();
    }
}
