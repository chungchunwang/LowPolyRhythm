using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ParticlesManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("How long the particle plays before it is destroyed.")]
    float particleDuration = 2f;
    [Header("Audio Settings: (optional)")]
    [SerializeField] AudioClip particleSound;
    [SerializeField] AudioMixerGroup audioOutput;
    [SerializeField] [Range(0,1)] float spatialBlend = 1;
    [SerializeField] [Range(-3,3)] float pitch = 1;
    [SerializeField] [Range(0,1)] float volume = 1;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitForSelfDestruction());
        if(particleSound != null){
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.clip = particleSound;
            audioSource.outputAudioMixerGroup = audioOutput;
            audioSource.spatialBlend = spatialBlend;
            audioSource.Play();
        }
    }
    IEnumerator waitForSelfDestruction(){
        yield return new WaitForSeconds(particleDuration);
        Destroy(gameObject);
    }
}
