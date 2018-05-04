using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TossWhenHit : MonoBehaviour
{
    bool animate = false;
    WallStreet Mur;
    public GameObject prefab;
    public LayerMask layer;
    public float distance, tailleOil;
	public CollideBoxDestroy detruire;
	public bool mesBoules = true
		;
	float animationTime = 0.5f;

    public int cote; //0 pour gauche, 1 pour droite.
                     // Use this for initialization

	IEnumerator RaycastRoutine(Vector2 position,int cpt,float size)
    {
		cpt = Mathf.Clamp (cpt, 1, 8);
        for (int i = 0; i < cpt; i++)
        {
            position.x += size;
			Instantiate(prefab, new Vector3(position.x, position.y-0.5f, 0.0f), Quaternion.identity);
             yield return new WaitForSeconds(1/5);

             //yield return new WaitForSeconds(0);
            }
        
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (animate)
        {
			if (animationTime >= 0)
				animationTime -= Time.deltaTime;
			else {
				Vector2 barilEnCours = transform.parent.position;
				Vector2 directionRaycast;
				if (cote == 0)
					directionRaycast = Vector2.right;
				else
					directionRaycast = Vector2.left;

				RaycastHit2D hit = Physics2D.Raycast (barilEnCours, directionRaycast, distance, layer);
				if (hit.collider != null) {
					float newdistance;
					int spawnCount;

					newdistance = hit.point.x - (barilEnCours.x);
					spawnCount = (int)Mathf.Abs (newdistance / tailleOil);
					if (cote == 1) {
						tailleOil = tailleOil * -1f;
						barilEnCours.x -= 0.5f;
					} else
						barilEnCours.x += 0.5f;
					StartCoroutine (RaycastRoutine (new Vector2 (barilEnCours.x, barilEnCours.y), spawnCount, tailleOil));
				}
			
				animate = false;
				//}
				//Destroy(transform.parent.GetChild(1));
			//	Destroy(transform.parent.GetChild (0));
			}
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
		if (other.tag == "Player1" && Input.GetButtonDown("ButtonA1") && mesBoules|| mesBoules && other.tag == "Player2" && Input.GetButtonDown("ButtonA2"))
           {
            	//Input.GetButtonDown("ButtonA1"))
				FlipObject();
			detruire.DesactiveCollideBox ();
           }
    }

    void FlipObject()
    {
		if (cote == 1) {
			transform.parent.rotation = Quaternion.Euler (0, 180, 0);
		}
		transform.parent.GetComponent<Animator> ().SetBool ("Tomber", true);
         animate = true;
    }

}
    