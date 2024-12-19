using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class TransformScript : MonoBehaviour
{
    public GameObject transformedPrefab;

    public AudioClip splash;

    public AudioSource splashSource;

    public GameObject transformEffect;

    public AudioSource transformSoundSource;
    public AudioClip transformSoundEffect;

    public float spawnTime = 2;

    public float upForce = 1f;
    //i don't think the upForce part of this works

    public int shelfItemsThrown = 0;
    
    //trash can particle effect
    public GameObject trashHighlighter;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shelfItemsThrown >= 8)
        {
            //trash can particle effect triggers to tell you you can move it
            trashHighlighter.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //separate them by tags to decide what turns into what?
        //TODO: delineate based on tags?
        if (other.tag == "ThrownItem")
        {
            shelfItemsThrown++;
        }
        
        splashSource.PlayOneShot(splash);
        Destroy(other.gameObject);
        Instantiate(transformEffect);
        InvokeRepeating("Spawn", 1.5f, spawnTime);
    }

    void Spawn()
    {
        Vector3 randScale = new Vector3(Random.Range(0.01f, 0.3f), Random.Range(0.01f, 0.3f));
        transformedPrefab.transform.localScale = randScale;
        Instantiate(transformedPrefab);
        transformSoundSource.PlayOneShot(transformSoundEffect);
        transformedPrefab.GetComponent<Rigidbody2D>().AddForce(transform.up * upForce);
    }
    //on trigger enter, set this object to inactive
    //instantiate effect prefab
    //instantiate the transformed prefab a bunch of times

    public void StopSpawn()
    {
        CancelInvoke("Spawn");
    }
    
}
