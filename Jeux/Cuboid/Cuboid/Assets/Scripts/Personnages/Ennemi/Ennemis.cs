﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using UnityEditor;


[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class Ennemis : Personnages {
    #region Variable
    public enum typeAttaque { Rien = 0, Tirer = 1, Kamikaze = 2, Explosion = 3}
    public enum typeDeplac { Immobile = 0, Voler = 1, Glisser = 2 }

    static float distActivation = 50;

    private PlayerCharacter2D en;
    private bool searchingForPlayer = false;

    public PersoStats ennemiStats = new PersoStats();
    public Comportement comp;

    private Rigidbody2D rb;
    private EnnemiAI artIntel;
    private WeaponEnnemi weapon;
    private PatrolControl control;
    //private SpriteRenderer sprite;
    private SpriteMask m_mask;

    public Vector2 direction;
    public Vector2 directionTir = new Vector2(0,0);
    public bool facingRight = false;

    private Transform myTransform;

    private bool ia = false;
    public bool tirerSurJoueur = false;

    public float decelleration = 2f;

    private bool smokeSet = false;
    public bool m_fumer = true;

    [HideInInspector]
    public bool activer = true;
    #endregion
    #region Corps
    private void Start() {
        myTransform = transform;
        rb = GetComponent<Rigidbody2D>() as Rigidbody2D;

        if (GetComponent<EnnemiAI>() != null) {
            ia = true;
            artIntel = GetComponent<EnnemiAI>() as EnnemiAI;
        }

        if (GetComponent<WeaponEnnemi>() != null)
            weapon = GetComponent<WeaponEnnemi>() as WeaponEnnemi;

        if (GetComponent<PatrolControl>() != null) {
            control = GetComponent<PatrolControl>() as PatrolControl;
            direction.x = control.direction.x;
            //myTransform.localScale = new Vector2(myTransform.localScale.x * -direction.x, myTransform.localScale.y);
        }

        if(GetComponent<SpriteMask>() != null)
        {
            m_mask = GetComponent<SpriteMask>() as SpriteMask;
        }

        rb.gravityScale = (comp.deplacement == typeDeplac.Voler) ? 0 : rb.gravityScale;
        directionTir.x = (facingRight) ? 1 : -1;

        if (en == null) {
            if (!searchingForPlayer) {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
        }

        StartCoroutine(CheckDistance());
    }

    private void FixedUpdate() {

        if (ia)
            artIntel.iaUpdate();
        else if (control != null)
            direction = control.checkDirection();

        if (en == null) {
            if (!searchingForPlayer) {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }
        if(activer)
            Deplacement(direction);

        if (rb.velocity.x > ennemiStats.maxSpeed)
            rb.velocity = Vector2.right * ennemiStats.maxSpeed;
        else if (rb.velocity.x < -ennemiStats.maxSpeed)
            rb.velocity = Vector2.right * -ennemiStats.maxSpeed;

        Attaque();
    }

    public override void DommagePerso(int dommage) {
        
        if (!ennemiStats.immortel) {
            ennemiStats.immortel = true;
            StartCoroutine(ChangeImmortel());
            ennemiStats.vie -= dommage;

            if (ennemiStats.vie <= 0) {

                if (smokeSet == true)
                {
                    foreach (Transform child in transform)
                    {
                        if (child.tag == "SmokeEffect")
                        {
                            child.GetComponent<ParticleSystem>().Stop();
                            child.SetParent(null, false);
                            break;
                        }
                    }
                }

                //  m_fumer est false seulement pour les boss qui rotation, il explose déjà
                if(m_fumer == true)
                {
                    GameMaster gm = GameObject.Find("_GM").GetComponent<GameMaster>();
                    GameObject ex = Instantiate(gm.m_explosionEnnemis, transform.position, transform.rotation);
                    if (FindObjectOfType<AudioManager>() != null)
                        FindObjectOfType<AudioManager>().Play("SmallExplosion");

                    Sequence explose = DOTween.Sequence();
                    explose.SetDelay(1.0f);
                    explose.AppendCallback(() =>
                    {
                        Destroy(ex);
                    });
                    explose.Play();

                }

                GameMaster.KillEnnemi(this);
                return;
            }

            if (FindObjectOfType<AudioManager>() != null)
                FindObjectOfType<AudioManager>().Play("HurtEnnemi");

            if (GetComponent<Dommage_Shader>() != null)
                GetComponent<Dommage_Shader>().CouleurDommage();
            else if(m_mask != null)
                m_mask.alphaCutoff = ((float)ennemiStats.vie / (float)ennemiStats.vieMax);

            if(ennemiStats.vie <= (ennemiStats.vieMax / 2.0f) && smokeSet == false)
            {
                GameMaster gm = GameObject.Find("_GM").GetComponent<GameMaster>();
                Instantiate(gm.m_smokeEffect, transform.position, Quaternion.Euler(-90.0f, 0.0f, 0.0f), transform);
                smokeSet = true;
            }

            //Debug.Log("pourcentage de vie restant = " + ((float)ennemiStats.vie / (float)ennemiStats.vieMax));

            //m_mask.alphaCutoff = ((float)ennemiStats.vie / (float)ennemiStats.vieMax);
        }
    }

    public override void SoinPerso(int valeur)
    {
        ennemiStats.vie += valeur;

        if (ennemiStats.vie > ennemiStats.vieMax)
            ennemiStats.vie = ennemiStats.vieMax;

        if (m_mask != null)
            m_mask.alphaCutoff = ((float)ennemiStats.vie / (float)ennemiStats.vieMax);

        if (ennemiStats.vie > (ennemiStats.vieMax / 2.0f) && smokeSet == true)
        {
            foreach (Transform child in transform)
            {
                if(child.tag == "SmokeEffect")
                {
                    child.GetComponent<ParticleSystem>().Stop();
                    smokeSet = false;
                    break;
                }
            }
        }
        //throw new NotImplementedException();
    }

    public void Attaque() {
        switch (comp.attaque) {
            case typeAttaque.Tirer:
                weapon.Tirer(directionTir, comp.dmgAttaque, comp.fireRate, tirerSurJoueur);
                break;

            case typeAttaque.Explosion:
                weapon.Explosion(comp.dmgAttaque, en, comp.fireRate);
                break;

            default:
                break;
        }
    }

    public void Deplacement(Vector2 dir) {

        switch (comp.deplacement) {
            case typeDeplac.Voler:
                dir *= ennemiStats.speed * Time.fixedDeltaTime;
                rb.AddRelativeForce(dir, ennemiStats.fMode);
                break;

            case typeDeplac.Glisser:
                dir *= ennemiStats.speed * Time.fixedDeltaTime;
                rb.AddRelativeForce(dir, ennemiStats.fMode);

                Vector2 velo = new Vector2(-rb.velocity.x * decelleration, 0);
                rb.AddRelativeForce(velo);
                break;

            default:
                Vector2 velo2 = new Vector2(-rb.velocity.x * decelleration, 0);
                rb.AddRelativeForce(velo2);
                break;
        }

        if (ia) {
            if (!tirerSurJoueur)
                DirectionTarget();
            else
                directionTir.x = 0;
        }
            
        else if (comp.deplacement != typeDeplac.Immobile) {
            direction = dir;
            directionTir = dir;
        }

    }

    void DirectionTarget() {
        if (artIntel.target.transform.position.x < myTransform.position.x)
            directionTir.x = -1;
        else
            directionTir.x = 1;
    }

    [System.Serializable]
    public class Comportement {

        public bool contact;
        public int dmgContact = 0;

        [SerializeField] public DegatAttaque statAttaque;
        public typeAttaque attaque;

        public int dmgAttaque;
        public float fireRate = 0.5f;

        public typeDeplac deplacement;
    }
    #endregion
    #region Collision
    private void OnCollisionEnter2D(Collision2D collision) {
        GameObject go = collision.gameObject;

        if (go.tag == "Player") {
            if (comp.contact)
                weapon.Contact(comp.dmgContact, en, comp.statAttaque.ePower);

            
            if (comp.attaque == typeAttaque.Kamikaze) {
                weapon.Explosion(comp.dmgAttaque, en, comp.fireRate);

                GameMaster gm = GameObject.Find("_GM").GetComponent<GameMaster>();
                GameObject ex = Instantiate(gm.m_explosionEnnemis, transform.position, transform.rotation);
                FindObjectOfType<AudioManager>().Play("SmallExplosion");

                Sequence explose = DOTween.Sequence();
                explose.SetDelay(1.0f);
                explose.AppendCallback(() =>
                {
                    Destroy(ex);
                });

                explose.Play();
                GameMaster.KillEnnemi(this);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        GameObject go = collision.gameObject;
        if (go.tag == "KillZone")
            GameMaster.KillEnnemi(this);
    }
    #endregion
    #region Activation
    //**** Activation/ Desactivation par rapport à la distance ****//
    IEnumerator CheckDistance() {
       
        if (en == null) {
            if (!searchingForPlayer) {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            yield break;
        }

        if ((en.transform.position - myTransform.position).sqrMagnitude < distActivation * distActivation)
            enabled = true;
        else {
            if(rb.bodyType != RigidbodyType2D.Static)
                rb.velocity = new Vector2(0,0);
            enabled = false;
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(CheckDistance());
    }
    #endregion
    IEnumerator SearchForPlayer() {
        GameObject sResult = GameObject.FindGameObjectWithTag("Player");
        if (sResult == null) {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchForPlayer());
        } else {
            en = sResult.GetComponent<PlayerCharacter2D>() as PlayerCharacter2D;
            searchingForPlayer = false;
            StartCoroutine(CheckDistance());
            yield break;
        }
    }

    IEnumerator ChangeImmortel() {
        yield return new WaitForSeconds(0.1f);
        ennemiStats.immortel = false;
    }
#if UNITY_EDITOR
    //Put gui elements for custom inspector here

    [HideInInspector] public bool showVie;
    [HideInInspector] public bool showDommage;
    [HideInInspector] public bool showContactDommage;
    [HideInInspector] public bool showMouvement;
    [HideInInspector] public bool showElements;
#endif
}