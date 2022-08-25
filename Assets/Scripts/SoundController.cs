using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip pickUpSound;
    public AudioClip winSound;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void PlayPickupSound()
    {
        PlaySound(pickUpSound);
    }
    public void PlayWinSound()
    {
        PlaySound(winSound);
    }

    void PlaySound(AudioClip _newSound)
    {
        audioSource.clip = _newSound;
        audioSource.Play();
    }

    public void PlayCollisionSound(GameObject _go)
    {
        if (_go.GetComponent<AudioSource>() != null)
        {
            _go.GetComponent<AudioSource>().Play();
        }
    }
}
