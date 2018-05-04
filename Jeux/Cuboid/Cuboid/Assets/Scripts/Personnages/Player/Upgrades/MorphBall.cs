﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class MorphBall : MonoBehaviour {

    public Sprite morphSprite;
    public Sprite standardSprite;
    public LayerMask preventUnmorph;

    private bool ismorphed = false;

	void Start ()
    {
        preventUnmorph = LayerMask.GetMask("Obstacle");
    }
	
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("TriggerAction1"))
        {
            GameObject playergo = transform.root.gameObject;

            if (playergo.GetComponent<GrappleBeam>().isGrappleAttached)
            {
                return;
            }

            if (!ismorphed)
            {
                //Change le sprite           
                playergo.GetComponent<PlayerCharacter2D>().m_backSphere.transform.localScale = new Vector2(0.42f, 0.42f);

               // playergo.GetComponent<SpriteRenderer>().sprite = morphSprite;

                //Disable/change l'animator
                //playergo.GetComponent<Animator>().enabled = false;

                //Disable le collider standard
                //Active le petit collider
                CircleCollider2D col1 = playergo.GetComponents<CircleCollider2D>()[0];
                CircleCollider2D col2 = playergo.GetComponents<CircleCollider2D>()[1];
                if (col1.radius > col2.radius)
                {
                    col1.enabled = false;
                    col2.enabled = true;
                }
                else
                {
                    col1.enabled = true;
                    col2.enabled = false;
                }

                playergo.GetComponent<BoxCollider2D>().enabled = false;
                playergo.transform.Find("Weapon").gameObject.SetActive(false);

                ismorphed = true;
                playergo.GetComponent<PlayerCharacter2D>().SetMorph(ismorphed);
                playergo.GetComponent<Animator>().SetBool("Morphed", ismorphed);    
            }
            else
            {
                //Utilise le ceiling check pour voir si on peux unmorph
                if (!playergo.GetComponent<PlayerCharacter2D>().IsUnderCeiling())
                {
                    //Check sur la gauche et droite (tunnel vertical)
                    Debug.DrawRay(playergo.transform.position, playergo.transform.right, Color.green, 2f);
                    Debug.DrawRay(playergo.transform.position, playergo.transform.right * -1, Color.green, 2f);
                    var hitGauche = Physics2D.Raycast(playergo.transform.position, playergo.transform.right, 2f, preventUnmorph);
                    var hitDroite = Physics2D.Raycast(playergo.transform.position, playergo.transform.right * -1, 2f, preventUnmorph);

                    if (hitGauche.collider != null)
                    {
                        Debug.Log("gauche");
                    }

                    playergo.GetComponent<PlayerCharacter2D>().m_backSphere.transform.localScale = new Vector2(1.0f, 1.0f);
                    playergo.transform.Find("Weapon").gameObject.SetActive(true);

                    ismorphed = false;
                    playergo.GetComponent<PlayerCharacter2D>().SetMorph(ismorphed);
                    playergo.GetComponent<Animator>().SetBool("Morphed", ismorphed);

                    //Active le collider standard
                    //Desactive le petit collider
                    CircleCollider2D col1 = playergo.GetComponents<CircleCollider2D>()[0];
                    CircleCollider2D col2 = playergo.GetComponents<CircleCollider2D>()[1];
                    if (col1.radius < col2.radius)
                    {
                        col1.enabled = false;
                        col2.enabled = true;
                    }
                    else
                    {
                        col1.enabled = true;
                        col2.enabled = false;
                    }
                    playergo.GetComponent<BoxCollider2D>().enabled = true;
                }
            }

        }
    }

}
