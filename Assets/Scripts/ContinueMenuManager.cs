using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueMenuManager : MonoBehaviour
{
    [SerializeField] private string playGameScene;
    [SerializeField] private string menuScene;

    public void PlayGame() {
        StartCoroutine(WaitAndChangeScene(playGameScene, 0.7f));
    }

    public void Back() {
        StartCoroutine(WaitAndChangeScene(menuScene, 0.7f));
    }

    private IEnumerator WaitAndChangeScene(string scene, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(scene);
    }
}
