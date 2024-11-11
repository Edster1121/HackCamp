using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalSelect : MonoBehaviour
{
    public string sceneName = "MainMenu"; // Specify the scene name you want to load

    void Update()
    {
        // Check if the Back Arrow or Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadPreviousScene();
        }
    }

    private void LoadPreviousScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
    public void onClickCat()
    {
        SceneManager.LoadScene("TodoListCat");
    }
    
    public void onClickDog()
    {
        SceneManager.LoadScene("TodoListDog");
    }
    
    public void onClickBunny()
    {
        SceneManager.LoadScene("TodoListBunny");
    }
}
