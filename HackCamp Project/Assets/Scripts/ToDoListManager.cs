using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ToDoListManager : MonoBehaviour
{
    public TMP_InputField inputField; // Drag your InputField here
    public Toggle toggle; // Drag the Toggle here
    public Image imageToChange; // Drag the Image component here
    public Sprite originalSprite; // Assign the default image here
    public Sprite newSprite; // Assign the image you want to show temporarily
    public float displayDuration = 2f; // Set how long the new image should display

    private void Start()
    {
        toggle.onValueChanged.AddListener(ToggleStrikethrough);
        toggle.onValueChanged.AddListener(OnToggleChanged);
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

    void ToggleStrikethrough(bool isChecked)
    {
        TMP_Text textComponent = inputField.textComponent;

        if (isChecked)
        {
            // Apply strikethrough to the InputField text using TMP's built-in style
            inputField.text = $"<s>{inputField.text}</s>";
            textComponent.color = new Color(0.5f, 0.5f, 0.5f); // Optional: Dim color
        }
        else
        {
            // Remove strikethrough by re-assigning plain text without formatting
            inputField.text = inputField.text.Replace("<s>", "").Replace("</s>", "");
            textComponent.color = Color.black; // Restore color
        }
    }
}
