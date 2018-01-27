using UnityEngine;

public class FootstepHandler : MonoBehaviour
{
    public AudioClip[] footstepSounds = new AudioClip[0];
    public AudioSource source;

    public void PlayFootstepSound(int i)
    {
        source.clip = footstepSounds[i];
        source.Play();
    }
}
