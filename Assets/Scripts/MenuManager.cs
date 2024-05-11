using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string levelName;
    //private GameObject menuPanel;

    public void PlayNewGame() {
        SceneManager.LoadScene(levelName);
    }

    public void Continue() {
        print("TODO CONTINUE GAME");
    }

    public void Credits() {
        print("TODO GAME CREDITS");
    }

    public void MonsterSheets() {
        print("TODO MONSTERSHEET");
    }

    public void Exit() {
        Application.Quit();
    }
}
