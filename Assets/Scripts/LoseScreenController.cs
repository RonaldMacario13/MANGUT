using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreenController : MonoBehaviour
{
    [SerializeField] private int scene;
    public GameObject deathScreen;

    void Start()
    {
        deathScreen.SetActive(false);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(scene);
    }
}
