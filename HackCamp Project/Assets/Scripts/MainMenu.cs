using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("petselectscene");
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
