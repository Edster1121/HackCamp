using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private bool isMuted = false; // Track mute status
    public Button muteButton; // Drag your button here
    public Image buttonImage; // Drag your button's Image component here
    public Sprite muteSprite; // Assign your mute image here
    public Sprite unmuteSprite; // Assign your unmute image here

    private void Awake()
    {
        // Make this object persistent across scenes
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        muteButton.onClick.AddListener(ToggleMute); // Add listener to mute button
    }

    // Toggle mute/unmute and switch the button image
    private void ToggleMute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            AudioListener.volume = 0f; // Mute the audio
            buttonImage.sprite = muteSprite; // Change to mute sprite
        }
        else
        {
            AudioListener.volume = 1f; // Unmute the audio
            buttonImage.sprite = unmuteSprite; // Change to unmute sprite
        }
    }
}