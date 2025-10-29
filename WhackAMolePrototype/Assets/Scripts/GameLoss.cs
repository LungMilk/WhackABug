using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoss : MonoBehaviour
{

    private void Start()
    {
        AsyncOperation asyncUnload =
        SceneManager.UnloadSceneAsync("GameOver");
        SceneManager.UnloadSceneAsync("StartScreenTest");

    }
    void Update()
    {
        //Currently a button input for testing, change to loss condition when possible
        if (Input.GetKeyDown("l"))
        {
            SceneManager.LoadSceneAsync("GameOver");
            SceneManager.UnloadSceneAsync("SampleScene");
            SceneManager.UnloadSceneAsync("StartScreenTest");
            Debug.Log("GameOver!!");
        }
    }
}
