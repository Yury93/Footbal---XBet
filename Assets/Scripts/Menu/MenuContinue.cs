using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuContinue : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void Start()
    {
        gameObject.SetActive(false);
    }



    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
