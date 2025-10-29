using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    private void Start()
    {
        AsyncOperation asyncUnload =
        SceneManager.UnloadSceneAsync("SampleScene");
        SceneManager.UnloadSceneAsync("StartScreenTest");

    }
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            SceneManager.LoadSceneAsync("SampleScene");
            SceneManager.UnloadSceneAsync("GameOver");
            Debug.Log("Restart!!");
        }
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadSceneAsync("StartScreenTest");
            SceneManager.UnloadSceneAsync("GameOvers");
            Debug.Log("Quit!!");
        }
    }
}
