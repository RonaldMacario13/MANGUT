using UnityEngine;
using UnityEngine.SceneManagement;

public class TrunkController : MonoBehaviour
{
    [SerializeField] private DetectionController _detectionArea;

    private Animator animator;

    public int sceneToChange;

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
                    Invoke(nameof(ChangeScene), 3f);
                }
            }
        }
    }

    void ChangeScene() {
        SceneManager.LoadSceneAsync(sceneToChange);
    }
}
