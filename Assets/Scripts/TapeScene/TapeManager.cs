using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapeManager : MonoBehaviour
{
    [SerializeField] private TorqueController torqueController;
    [SerializeField] private Pointer pointer;
    [SerializeField] private Button activeButton1, activeButton2, activeButton3;
    public int IndexerPoint;
    private GameObject TapeGo;
    [SerializeField] private GameObject particalGo;
    
    private void Start()
    {
        torqueController.OnStopTape += TorqueController_OnStopTape;
        GoalkeeperMovement.OnActiveTape += GoalkeeperMovement_OnActiveTape;

        activeButton1.interactable = true;
        activeButton2.interactable = true;
        activeButton3.interactable = true;


        TapeGo = torqueController.gameObject;
        Time.timeScale = 5;
    }

    private void GoalkeeperMovement_OnActiveTape()
    {
        if (TapeGo)
        {
            TapeGo.SetActive(true);
        }
        torqueController.NewPlay();
        print("ActiveTape");
        GoalkeeperMovement.OnActiveTape -= GoalkeeperMovement_OnActiveTape;
        activeButton1.interactable = false;
        activeButton2.interactable = false;
        activeButton3.interactable = false;
    }

    private void TorqueController_OnStopTape()
    {
        StartCoroutine(CorPointIndex());
        IEnumerator CorPointIndex()
        {
            yield return new WaitForSeconds(1);
            IndexerPoint = pointer.Index;
            yield return new WaitForSeconds(0.1F);
            torqueController.gameObject.SetActive(false);
            pointer.gameObject.SetActive(false);
          

            activeButton1.interactable = true;
            activeButton2.interactable = true;
            activeButton3.interactable = true;

            GoalkeeperMovement.OnActiveTape += GoalkeeperMovement_OnActiveTape;
        }
    }
    public void TapeActiveGo()
    {
        torqueController.gameObject.SetActive(true);
        pointer.gameObject.SetActive(true);
        torqueController.NewPlay();

        activeButton1.interactable = false;
        activeButton2.interactable = false;
        activeButton3.interactable = false;
    }
    public void SetDisactiveButton()
    {
        //activeButton.interactable = false;
    }
    public void CreateParticleGoal(Vector3 pos)
    {
        Instantiate(particalGo, pos, Quaternion.identity);
    }

}
