using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBackground : MonoBehaviour
{
    private Vector3 startpos;
    private float backsize;
  
    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        backsize = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startpos.x - backsize)
        {
            transform.position = startpos;
        }
    }
}
