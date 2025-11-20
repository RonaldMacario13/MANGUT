using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    [SerializeField] private DetectionController _detectionArea;
    private PlayerController _playerController;

    void Start()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void DestroyFood() {
        if(Input.GetKeyDown("c")) {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (_detectionArea.detectedObjs.Count > 0)
        {
            if (Input.GetKeyDown("c"))
            {
                 if (_playerController != null)
                {
                    _playerController.RecoverFatRate(20f); // Recupera 20 de vida (ou reduz a gordura)
                    DestroyFood(); // Destroi o objeto de comida
                }
            }
        }
    }
}
