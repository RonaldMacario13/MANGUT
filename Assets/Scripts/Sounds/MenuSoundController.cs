using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusicController : MonoBehaviour
{
    private static MenuMusicController instance = null;

    [SerializeField] public string[] scenesWithMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (IsSceneInList(scene.name))
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    private bool IsSceneInList(string sceneName)
    {
        foreach (string scene in scenesWithMusic)
        {
            if (scene == sceneName)
            {
                return true;
            }
        }
        return false;
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}