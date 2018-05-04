using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreDepression : MonoBehaviour {

	public static float fillAmount = (float) 0.76;
	public Image content;
	public float VitesseBaisse;
	private float nextTime =0;
	private int interval =1;

	public  static int TEST = 2;


	void Start()
	{

		nextTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (PlayerController.musee == true) {

			if (TEST == 1) {


				nextTime = Time.time;
				PlayerController.musee = true;

				TEST = 2;
			}



			content.enabled = true;
			this.gameObject.GetComponent<Image>().enabled = true;

			if (Time.time >= nextTime) {
				Barre ();
				nextTime += interval; 

			}

		}

		if (PlayerController.musee == false) {
			this.gameObject.GetComponent<Image>().enabled = false;
			content.enabled = false;

		}


		
	}

	private void Barre()
	{	//Debug.Log (fillAmount);
		fillAmount = fillAmount - VitesseBaisse;
		content.fillAmount = fillAmount;

	}
}
