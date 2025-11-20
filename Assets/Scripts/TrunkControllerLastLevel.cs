using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkControllerLastLevel : MonoBehaviour
{
    [SerializeField] private DetectionController _detectionArea;

    public GameObject winScreen;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (_detectionArea.detectedObjs.Count > 0)
        {
            if (Input.GetKeyDown("c"))
            {
                if (animator != null)
                {
                    animator.SetTrigger("open");
                    Invoke(nameof(WinScreen), 2f);
                }
            }
        }
    }

    void WinScreen() {
        winScreen.SetActive(true);
    }
}
