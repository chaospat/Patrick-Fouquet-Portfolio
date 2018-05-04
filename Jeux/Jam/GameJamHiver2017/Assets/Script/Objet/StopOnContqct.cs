using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopOnContqct : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -5, 0);
    }
}
