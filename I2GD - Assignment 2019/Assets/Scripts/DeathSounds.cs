using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSounds : MonoBehaviour { 

    [SerializeField] private AudioClip[] deathSounds;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        int n = Random.Range(0, deathSounds.Length);
        audioSource.clip = deathSounds[n];
        audioSource.PlayOneShot(audioSource.clip);
    }

}
