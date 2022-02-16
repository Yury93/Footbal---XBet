using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallKick : MonoBehaviour
{
    [SerializeField] private Vector3 right, middle, left;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    public Rigidbody RB => rb;
    [SerializeField]private bool kick = false;
    private Vector3 movement;
    private Vector3 startPos;
    public Vector3 StartPos => startPos;
    [SerializeField] private TorqueController torqueController;
    [SerializeField] private TapeManager tapeManager;
    [SerializeField] private Text textTape;

    private void Start()
    {
        startPos = transform.position;
        torqueController.OnStopTape += TorqueController_OnStopTape;
    }

    private void TorqueController_OnStopTape()
    {
        DirectionKick();
    }

    private void FixedUpdate()
    {
        if (kick)
        {
            rb.velocity = movement * speed * Time.fixedDeltaTime;
            kick = false;
        }
    }
    public void DirectionKick()
    {
        kick = true;
        if (tapeManager.IndexerPoint == 1)
        {
            textTape.gameObject.SetActive(true);
            textTape.text = "Punch to the right!";
            movement = right;
            tapeManager.GetComponent<AudioSource>().Play();
            tapeManager.SetDisactiveButton();
            StartCoroutine(CorTextDisabled());
        }
        if (tapeManager.IndexerPoint == 2)
        {
            textTape.gameObject.SetActive(true);
            textTape.text = "Punch in the middle!";
            movement = middle;
            tapeManager.GetComponent<AudioSource>().Play();
            tapeManager.SetDisactiveButton();
            StartCoroutine(CorTextDisabled());
        }
        if (tapeManager.IndexerPoint == 3)
        {
            textTape.gameObject.SetActive(true);
            textTape.text = "Left kick!";
            movement = left;
            tapeManager.GetComponent<AudioSource>().Play();
            tapeManager.SetDisactiveButton();
            StartCoroutine(CorTextDisabled());
        }
    }
    IEnumerator CorTextDisabled()
    {
        yield return new WaitForSeconds(5f);
        textTape.gameObject.SetActive(false);
    }
}
