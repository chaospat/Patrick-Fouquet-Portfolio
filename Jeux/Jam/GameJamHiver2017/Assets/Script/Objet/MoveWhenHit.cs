using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWhenHit : MonoBehaviour {

    public Boundary limite;
    public bool inWall = false;
    public float speedX, speedY ;
  

    // Update is called once per frame
      
    void Update()
    {
    }
   
    void OnTriggerStay2D(Collider2D other)
    {
        if (inWall == false)
        {
			if (other.tag == "Player1" && Input.GetButtonDown("ButtonA1") || other.tag == "Player2" && Input.GetButtonDown("ButtonA2"))
            {
				transform.parent.GetComponent<Rigidbody2D>().velocity = new Vector3(speedX, speedY, 0);
                Destroy(this);
            }
        }
    }


    public void InWallInterupt()
    {
        inWall = true;
    }


}
