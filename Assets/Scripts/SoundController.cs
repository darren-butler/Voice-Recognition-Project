using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController soundController;

    private AudioSource audioSource;

    private AudioClip coinSound;
    private AudioClip shieldSound;

    // Start is called before the first frame update
    void Start()
    {
        soundController = this;
        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();

        coinSound = Resources.Load<AudioClip>("SFX/coin");
        shieldSound = Resources.Load<AudioClip>("SFX/spaceEngine_000");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayCoinSound()
    {
        audioSource.PlayOneShot(coinSound);
    }

    public void PlayShieldSound()
    {
        audioSource.PlayOneShot(shieldSound, 0.1f);
    }
}
