using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweeper : MonoBehaviour
{

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground"))

        {
            Destroy(collision.gameObject);
        }
    }
}
