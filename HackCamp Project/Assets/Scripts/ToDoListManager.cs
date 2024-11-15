using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToDoListManager : MonoBehaviour
{
    public TMP_InputField[] inputFields; // Drag your 10 InputFields here
    public Toggle[] toggles; // Drag your 10 Toggles here
    public Image imageToChange; // Drag the single Image component here
    public Sprite originalSprite; // Assign the default image here
    public Sprite newSprite; // Assign the image you want to show temporarily
    public float displayDuration = 2f; // Set how long the new image should display
    public string sceneName = "PetSelect"; // Specify the scene name you want to load
    void Update()
    {
        // Check if the Back Arrow or Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadPreviousScene();
        }
        if (AreAllTogglesOn())
        {
            // Change scene if all toggles are on
            LoadCongratScene();
        }
    
        
    }

    private void LoadPreviousScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
    
    private bool AreAllTogglesOn()
    {
        // Iterate over each toggle in the toggles array
        foreach (Toggle toggle in toggles)
        {
            if (!toggle.isOn) // If any toggle is off, return false
            {
                return false;
            }
        }
        // If all toggles are on, return true
        return true;
    }

    private void LoadCongratScene()
    {
        SceneManager.LoadScene("Congratulations");
    }

    private void Start()
    {
        for (int i = 0; i < toggles.Length; i++)
        {
            int index = i; // Store the current index for use in the lambda expression
            toggles[index].onValueChanged.AddListener(isChecked => ToggleStrikethrough(index, isChecked));
            toggles[index].onValueChanged.AddListener(OnToggleChanged); // No index needed here
        }
    }

    private void OnToggleChanged(bool isChecked)
    {
        if (isChecked)
        {
            // Start the coroutine to change the image temporarily
            StartCoroutine(ChangeImageTemporarily());
        }
    }

    private IEnumerator ChangeImageTemporarily()
    {
        // Change to the new image
        imageToChange.sprite = newSprite;

        // Wait for the specified duration
        yield return new WaitForSeconds(displayDuration);

        // Revert to the original image
        imageToChange.sprite = originalSprite;
    }

    private void ToggleStrikethrough(int index, bool isChecked)
    {
        TMP_Text textComponent = inputFields[index].textComponent;

        if (isChecked)
        {
            // Apply strikethrough to the InputField text using TMP's built-in style
            inputFields[index].text = $"<s>{inputFields[index].text}</s>";
            textComponent.color = new Color(0.5f, 0.5f, 0.5f); // Optional: Dim color
        }
        else
        {
            // Remove strikethrough by re-assigning plain text without formatting
            inputFields[index].text = inputFields[index].text.Replace("<s>", "").Replace("</s>", "");
            textComponent.color = Color.black; // Restore color
        }
    }
}
