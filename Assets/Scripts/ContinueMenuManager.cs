using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueMenuManager : MonoBehaviour
{
    [SerializeField] private string playGameScene;
    [SerializeField] private string menuScene;

    public void PlayGame() {
        SceneManager.LoadScene(playGameScene);
    }

    public void Back() {
        SceneManager.LoadScene(menuScene);
    }
}
