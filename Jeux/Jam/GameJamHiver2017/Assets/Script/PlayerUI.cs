using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour {
	
	public PlayerController player;
	public SpriteRenderer arme;
	public SpriteRenderer barre;
	public SpriteRenderer buff;
	public Sprite bone;
	public Sprite knife;
	public Sprite seringue;
	public Sprite pills;
	public Sprite vitesseUP;
	public Sprite vitesseDOWN;
	public Sprite powerUp;

	// Use this for initialization
	void Start () {
		arme.sprite = null;
		buff.sprite = null;
		//buff.GetComponentsInChildren<SpriteRenderer> () = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetArme(string name) {
		switch (name) {
		case "Couteau":
			arme.sprite = knife;
			break;
		case "Os":
			arme.sprite = bone;
			break;
		case "Seringue":
			arme.sprite = seringue;
			//setEffect ("vitesseUP");
			break;
		case "Pills":
			arme.sprite = pills;
			//setEffect ("PowerUp");
			break;
		default:
			arme.sprite = null;
			break;

		}

	}

	public void setEffect(string name) {
		switch (name) {
		case "vitesseUP":
			buff.sprite = vitesseUP;
			break;
		case "vitesseDOWN":
			buff.sprite = vitesseDOWN;
			break;
		case "PowerUp":
			buff.sprite = powerUp;
			break;
		default:
			buff.sprite = null;
			break;
		
		}

	}

}
