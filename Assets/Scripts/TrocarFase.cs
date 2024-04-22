using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarFase : MonoBehaviour
{

    [SerializeField]
    private string nomeDaFase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CarregarNovaFase()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nomeDaFase);
    }

}
