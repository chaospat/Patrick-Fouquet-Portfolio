using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallStreet : MonoBehaviour {
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bed")
        {
            other.transform.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -2, 0);
        }
		if (other.tag == "OsLancee" || other.tag == "couteau")
			Destroy (other.gameObject);

    }
}
