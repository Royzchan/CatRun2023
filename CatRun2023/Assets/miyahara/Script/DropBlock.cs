using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DropBlock : MonoBehaviour
{

    public GameObject dropFloor;
    private Rigidbody rb;

    [SerializeField]
    private float DropSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            rb.velocity = new Vector3(0f, DropSpeed, 0f);
            
        }
       
    }

}