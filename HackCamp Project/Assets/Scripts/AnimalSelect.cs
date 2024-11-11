using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalSelect : MonoBehaviour
{
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
    public void onBackClick()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
