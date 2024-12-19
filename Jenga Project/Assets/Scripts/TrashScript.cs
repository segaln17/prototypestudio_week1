using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    public GameObject trashEffect;
    public AudioSource crumpleSource;
    public AudioClip crumpleEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        Instantiate(trashEffect, transform.position, transform.rotation);
        crumpleSource.PlayOneShot(crumpleEffect);
    }
}
