using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component

    public void StopAudio()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop(); // Stops the audio
        }
    }
}
