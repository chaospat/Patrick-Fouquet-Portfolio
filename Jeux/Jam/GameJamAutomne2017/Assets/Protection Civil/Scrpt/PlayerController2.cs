using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax;
	}

public class PlayerController2 : MonoBehaviour {

	public float speed = 2.0f;
	public Boundary boundary;
	
	public GameObject coup;
	public Transform coupSpawn;
	public float punchRate;
	
	private float nextPunch;

	private Animator anim;


	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update()
	{
		//PARTIE 1 : TIR
		if (Input.GetKeyDown("space") && Time.time > nextPunch){
			nextPunch = Time.time + punchRate;
			anim.SetTrigger("punch");
			GameObject coups = Instantiate(coup, coupSpawn.position, coupSpawn.rotation);
			coups.transform.parent = gameObject.transform;
			}
		/////////////////////////////////////
	}
	
	void FixedUpdate ()
	{
	
		//PARTIE 1 : MOUVEMENT////
		Vector3 direction = new Vector3(Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0.0f);
		Vector3 newPos = transform.position + direction*speed;

		if(direction.x != 0 || direction.y!=0)
			anim.SetFloat("speed",1.0f);
		else
			anim.SetFloat("speed",0.0f);
		
		newPos.x = Mathf.Clamp(newPos.x, boundary.xMin, boundary.xMax);
		newPos.y = Mathf.Clamp(newPos.y, boundary.yMin, boundary.yMax);
	
		transform.position = newPos;

		}
	}