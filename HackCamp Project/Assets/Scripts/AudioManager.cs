using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    public AudioSource bgmSource; // Reference to the background music AudioSource
    private bool isMuted = false; // Track mute status
    public Button muteButton; // Mute/unmute button
    public Image buttonImage; // Image on the mute/unmute button
    public Sprite muteSprite; // Mute sprite
    public Sprite unmuteSprite; // Unmute sprite

    private void Awake()
    {
        // Check if there's already an instance of AudioManager
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object persistent across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    private void Start()
    {
        if (muteButton != null)
        {
            muteButton.onClick.AddListener(ToggleMute); // Add listener to mute/unmute button
        }

        // Set initial BGM state
        UpdateMuteState();
    }

    // Toggle mute/unmute and switch the button image
    private void ToggleMute()
    {
        isMuted = !isMuted;
        UpdateMuteState();
    }

    // Update the mute/unmute state
    private void UpdateMuteState()
    {
        if (isMuted)
        {
            AudioListener.volume = 0f; // Mute the audio
            bgmSource.mute = true; // Mute the background music
            buttonImage.sprite = muteSprite; // Change to mute sprite
        }
        else
        {
            AudioListener.volume = 1f; // Unmute the audio
            bgmSource.mute = false; // Unmute the background music
            buttonImage.sprite = unmuteSprite; // Change to unmute sprite
        }
    }
}