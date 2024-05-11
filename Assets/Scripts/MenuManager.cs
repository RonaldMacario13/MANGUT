using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string newGameScene;
    [SerializeField] private string continueScene;
    [SerializeField] private string creditsScene;
    [SerializeField] private string monsterSheetScene;
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
        SceneManager.LoadScene(monsterSheetScene);
    }

    public void Exit() {
        Application.Quit();
    }
}
