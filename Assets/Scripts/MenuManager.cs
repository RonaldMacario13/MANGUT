using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string levelName;
    //private GameObject menuPanel;

    public void Play() {
        SceneManager.LoadScene(levelName);
    }

    public void Exit() {
        Application.Quit();
    }
}
