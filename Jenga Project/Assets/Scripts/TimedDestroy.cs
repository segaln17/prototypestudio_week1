using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float destroyTime = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, destroyTime);
        
    }
    
}
