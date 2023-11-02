using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Normal.Realtime;

public class MultiplayerAudioSource : MonoBehaviour
{
    [SerializeField] private XRGrabInteractable xRGrabInteractable;
    [SerializeField] private RealtimeTransform realtimeTransform;
    private AudioSource audioSource;
    private bool isAudioPlaying;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        xRGrabInteractable.selectEntered.AddListener(StartAudioPlayback);
        xRGrabInteractable.selectExited.AddListener(StopAudioPlayback);
    }

    private void OnDisable()
    {
        xRGrabInteractable.selectEntered.RemoveListener(StartAudioPlayback);
        xRGrabInteractable.selectExited.RemoveListener(StopAudioPlayback);
    }

    private void StartAudioPlayback(SelectEnterEventArgs args)
    {
        isAudioPlaying = true;
        // You can also use RealtimeTransform to synchronize the audio source's position.
        audioSource.Play();
    }

    private void StopAudioPlayback(SelectExitEventArgs args)
    {
        isAudioPlaying = false;
        audioSource.Stop();
    }

    private void Update()
    {
        if (isAudioPlaying)
        {
            // Update the position of the GameObject containing the audio source
            // using RealtimeTransform if needed.
            realtimeTransform.transform.localPosition = transform.position;
        }
    }
}