using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarFase : MonoBehaviour
{

    [SerializeField] private string nomeDaFase;
    [SerializeField] private detecController detectionArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(detectionArea);
        if(Input.GetKeyDown(KeyCode.Tab) & detectionArea.detectedObjs.Count > 0)
        {
            CarregarNovaFase();
        }
    }

    private void CarregarNovaFase()
    {
        SceneManager.LoadScene(nomeDaFase);
    }

}
