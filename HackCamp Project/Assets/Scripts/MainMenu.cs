using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("PetSelect");
    }

    public void Quit()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
