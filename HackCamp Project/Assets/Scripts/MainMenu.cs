using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("PetSelect");
    }
    
    void Update()
    {
        // Check if the Back Arrow or Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
        }
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
