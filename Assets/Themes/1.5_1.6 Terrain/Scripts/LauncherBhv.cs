using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class LauncherBhv : MonoBehaviour
{
    public AudioSource LauncherAudioSourse { get; private set; }

    void Start()
    {
        LauncherAudioSourse = GetComponent<AudioSource>();
    }   
}
