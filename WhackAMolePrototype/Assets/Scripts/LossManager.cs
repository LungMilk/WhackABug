using UnityEngine;
using UnityEngine.SceneManagement;

public class LossManager : MonoBehaviour
{
    public static LossManager instance { get; private set; }
    public bool reachedEnd;
    public string LossName;

    private void Start()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    public void End()
    {
        print("end");
        //SceneManager.LoadSceneAsync("GameOver");
        //SceneManager.UnloadSceneAsync("SampleScene");
        //SceneManager.UnloadSceneAsync("StartScreenTest");
        // Application.Quit();
        Time.timeScale = 0f;
        Debug.Log("GameOver!!");
    }
}
