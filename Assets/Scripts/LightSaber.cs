using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSaber : MonoBehaviour
{
    public AudioClip beamAudio;

    private AudioSource audioSource;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void TriggerBeam()
    {
        bool isOn = animator.GetBool("LightSaberOn");
        /*
        if (!isOn)
            audioSource.PlayOneShot(beamAudio);
        else
            audioSource.Stop();
        */
        animator.SetBool("LightSaberOn", !isOn);
    }
}