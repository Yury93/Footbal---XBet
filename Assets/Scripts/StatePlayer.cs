using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePlayer : MonoBehaviour
{
    public enum Mode
    {
        move,
        kick
    }
    [SerializeField] private float speed,startSpeed;

    private CharacterController charContrl;
    [SerializeField] private Joystick joystick;
    private float gravity = -9.87f;
    private float deltaX, deltaZ;

    [SerializeField] private Mode mode = Mode.move;
    public Mode GetMode => mode;

    [SerializeField] private bool AI;
    public bool Ai => AI;
    private MovementBall ball;

    [SerializeField] private GameObject childObject;
    private bool ballToAi;
    private void Start()
    {
        charContrl = GetComponent<CharacterController>();
        startSpeed = speed;
    }
    private void Update()
    {
        if (mode == Mode.move)
        {
            JoysticActive();
            MovePlayer();
            MoveAI();
        }
    }
    private void FixedUpdate()
    {
        if(speed > startSpeed)
        {
            speed -= Time.fixedDeltaTime/10;
        }
        else if(speed > 3.5)
        {
            speed -= Time.fixedDeltaTime;
        }
    }
    private void MovePlayer()
    {
        if (!Ai)
        {
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement.y = gravity;
            movement *= Time.deltaTime;
            movement = transform.TransformDirection(movement);

            charContrl.Move(movement);
           
        }
    }
    public void SetRotation()
    {
        if (transform.rotation.y == 0)
        {
            transform.Rotate(0, 90, 0);
        }
        else
        {
            transform.Rotate(0, -90, 0);
        }
    }
    private void MoveAI()
    {
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        if (AI)
        {
            if (!ball)
            {
                ball = FindObjectOfType<MovementBall>();
            }
            if (ball)
            {
                childObject.transform.LookAt(ball.transform.position);
                var direction = ball.transform.position - transform.position;
                if(ballToAi)
                {
                    direction = new Vector3(0, 0, -speed);
                }
                movement = Vector3.Lerp(transform.position, direction, 1);
            }
        }
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        charContrl.Move(movement);
    }
    private void JoysticActive()
    {
        if (joystick)
        {
            deltaZ = speed;
            if (joystick.Direction.x < 0)
            {
                deltaX = -1 * speed;
            }
            else if (joystick.Direction.x > 0)
            {
                deltaX = 1 * speed;
            }
            else
            {
                deltaX = 0;
            }
        }
    }
    public void SetMode(string newMode)
    {
        if (newMode == "move")
        {
            mode = Mode.move;
        }
    }
    public void SetSpeed(int newSpeed)
    {
        if(!Ai)
        {
            speed += newSpeed;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (AI)
        {
            var ball = hit.gameObject.GetComponent<MovementBall>();
            if (ball)
            {
                ballToAi = true;
                Destroy(ball.gameObject, 10f);
                Destroy(gameObject, 10f);
            }
        }
    }
}
