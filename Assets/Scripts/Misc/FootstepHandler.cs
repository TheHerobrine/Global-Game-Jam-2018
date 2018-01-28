using UnityEngine;

public class FootstepHandler : MonoBehaviour
{
    public AudioClip[] footstepSoundsInside = new AudioClip[0];
    public AudioClip[] footstepSoundsOutside = new AudioClip[0];
    public AudioSource source;
    public EnvironmentManager envManager;

    private System.Random random;

    public void Start()
    {
        random = new System.Random();
    }

    public void PlayFootstepSound(int i)
    {
        AudioClip[] audioChoices = envManager.outside ? footstepSoundsOutside : footstepSoundsInside;
        source.clip = audioChoices[random.Next(0, audioChoices.Length)];
        source.Play();
    }
}
