using System;
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
        StartCoroutine(WaitAndChangeScene(newGameScene, 0.7f));
    }

    public void Continue() {
        StartCoroutine(WaitAndChangeScene(continueScene, 0.7f));
    }

    public void Credits() {
        StartCoroutine(WaitAndChangeScene(creditsScene, 0.7f));
    }

    public void MonsterSheets() {
        StartCoroutine(WaitAndChangeScene(monsterSheetScene, 0.7f));
    }

    public void Exit() {
        Application.Quit();
    }
    
    private IEnumerator WaitAndChangeScene(string scene, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
