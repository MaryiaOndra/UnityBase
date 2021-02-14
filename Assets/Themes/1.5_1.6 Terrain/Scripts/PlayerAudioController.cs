using UnityEngine;

namespace UnityBase.Terrain
{
    public class PlayerAudioController : MonoBehaviour
    {
        [SerializeField] AudioClip runClip;
        [SerializeField] AudioClip walkClip;

        AudioSource audioSource;
        PlayerController playerController;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            playerController = GetComponent<PlayerController>();
        }

        private void Update()
        {
            if (playerController.IsMoving)
            {
                if (!playerController.IsRunning)
                {
                    audioSource.clip = walkClip;
                }
                else
                {
                    audioSource.clip = runClip;
                }

                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                }
            }
            else
            {
                audioSource.Stop();
            }
        }
    }
}
