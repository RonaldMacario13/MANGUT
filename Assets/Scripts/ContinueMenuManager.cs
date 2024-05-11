using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueMenuManager : MonoBehaviour
{
    [SerializeField] private string levelName;

    public void PlayGame() {
        SceneManager.LoadScene(levelName);
    }

    public void Back() {
        SceneManager.LoadScene("Menu");
    }
}
