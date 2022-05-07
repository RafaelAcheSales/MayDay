using System.Collections;
using System.Collections.Generic;
using Gamekit2D;
using UnityEngine;

public class Laser : MonoBehaviour
{
    Damager damager;
    SpriteRenderer spriteRenderer;
    bool isFiring;
    public AudioSource audioSource;
    public float interval = 1f;

    void Start()
    {
        damager = GetComponent<Damager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        isFiring = false;
        InvokeRepeating("Fire", 0, interval);
    }

    void Fire()
    {
        if (!isFiring)
        {
            audioSource.Play();
            damager.EnableDamage();
            spriteRenderer.enabled = true;
            isFiring = true;
        } else {
            audioSource.Stop();
            damager.DisableDamage();
            spriteRenderer.enabled = false;
            isFiring = false;
        }
    }


}
