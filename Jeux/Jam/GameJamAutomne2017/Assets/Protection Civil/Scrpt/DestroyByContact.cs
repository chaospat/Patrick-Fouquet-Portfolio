using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
	
	public GameObject explosion;
	//public GameObject civilExplosion;
	public int scoreValue;
	public int dmg;
	
	public float destroyTime;
	private GameController gameController;
	
	public float punchPower;
	private Rigidbody2D rb;

	private bool alredyToucher = false;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameControllerCivil");
		if (gameControllerObject != null){
			gameController = gameControllerObject.GetComponent <GameController>();
			}
		else if (gameController == null){
			Debug.Log ("Cannot find 'GameControllerCivil' script");
			}
	
		rb = GetComponent<Rigidbody2D>();
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
	while(!gameController.gameOver){
		if (other.gameObject.tag == "Coup" || other.gameObject.tag == "Mob"){

			if(!alredyToucher){
				GameObject explo = Instantiate (explosion, transform.position, transform.rotation);
				Animator anim = explo.GetComponent<Animator>();

				if (other.gameObject.tag == "Coup")
					anim.SetInteger ("Anim", 3);
					
				if (other.gameObject.tag == "Mob")
					anim.SetInteger ("Anim", 2);

				Destroy (explo, 0.5f);
				alredyToucher = true;

				gameController.AddScore (scoreValue);
				Destroy(gameObject, destroyTime);
			}
					
		
			Vector2 forceAdd;
			if (other.gameObject.tag == "Coup")
				forceAdd = new Vector2 (punchPower * 100, Random.Range (-punchPower, punchPower) * 50);
			else
				forceAdd = other.rigidbody.velocity*10;
			
			rb.AddForce (forceAdd);
		
			return;
		
			}
	
		if (other.gameObject.tag == "Civil"){
				
			GameObject explo = Instantiate (explosion, transform.position, transform.rotation);
			Animator anim = explo.GetComponent<Animator>();
			anim.SetInteger ("Anim", 1);

			Destroy (explo, 0.5f);

			gameController.dmgCivil (dmg);
			Destroy(gameObject);
			return;
			}
		}
	}

	}