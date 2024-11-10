using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Test");
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
