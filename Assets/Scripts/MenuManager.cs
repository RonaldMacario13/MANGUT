using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string newGameScene;
    [SerializeField] private string continueScene;
    [SerializeField] private string creditsScene;
    //private GameObject menuPanel;

    public void PlayNewGame() {
        SceneManager.LoadScene(newGameScene);
    }

    public void Continue() {
        SceneManager.LoadScene(continueScene);
    }

    public void Credits() {
        SceneManager.LoadScene(creditsScene);
    }

    public void MonsterSheets() {
        print("TODO MONSTERSHEET");
    }

    public void Exit() {
        Application.Quit();
    }
}
