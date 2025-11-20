using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemController : MonoBehaviour
{
    [SerializeField] private DetectionController _detectionArea;
    [SerializeField] private GameObject quizObject;
    [SerializeField] private GameObject objectToDestroy;  
    private PlayerController _playerController;

    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        if (quizObject)
        {
            quizObject.SetActive(false);
        }
    }

    public void OpenQuiz() {
        quizObject.SetActive(true);

        objectToDestroy.SetActive(false);
    }
    
    void Update()
    {
        if (_detectionArea.detectedObjs.Count > 0)
        {
            if (Input.GetKeyDown("c"))
            {
                 if (_playerController != null)
                {
                    OpenQuiz();
                }
            }
        }
    }
}
