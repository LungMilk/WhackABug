using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    private void Start()
    {
        AsyncOperation asyncUnload =
        SceneManager.UnloadSceneAsync("GameOver");
        SceneManager.UnloadSceneAsync("SampleScene");

    }
    bool GameHasStart = false;
    void Update()
    {
        if (GameHasStart == false)
        {
            if (Input.GetKeyDown("f"))
            {
                //Called when button is pressed, loads main game scene. Change name to applicable if needed
                // Ok so I changed a lot. Above is what it did originally, I've changed it now so only the spatula is needed to play. Players hit the middle button which loads the 
                //game scene, once its happened once it cannot happen again until the game ends
                //Ok I changed it again, instead it just kills itself and loads the other scene as well
                SceneManager.LoadSceneAsync("SampleScene");
                SceneManager.UnloadSceneAsync("StartScreenTest");
                Debug.Log("Hello I am being called!!");
            }
        }
    }
}
