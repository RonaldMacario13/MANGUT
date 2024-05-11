using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenuManager : MonoBehaviour
{
    [SerializeField] private string menuScene;
    
    public void Back() {
        SceneManager.LoadScene(menuScene);
    }
}