﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using System;
using EZCameraShake;


public class GameMaster : MonoBehaviour {

    public static GameMaster instance;

    public int spawnDelay = 2;

    public float escapeSeconds = 10;

    public Transform spawnPoint;
    public Transform spawnPrefab;
    public Transform playerPrefab;
    public GameObject itemPickupPrefab;
    public GameObject m_smokeEffect;
    public GameObject m_explosionEnnemis;

    private GameObject tmpPlayer;

    private GameObject escapeTimer;
    public bool timerRunning = false;
    private float currentTime = 0f;

    void Awake() {
        Cursor.visible = false;

        //  ça marche pu quand on load la scene depuis le menu, il est setter dans boss.cs
        //  la méthode qui le set est ResetEscapeObject

        /*if (GameObject.FindGameObjectWithTag("EscapeTimerUI"))
        {
            escapeTimer = GameObject.FindGameObjectWithTag("EscapeTimerUI");
        }
        escapeTimer.SetActive(false);*/

        if (instance == null)
            instance = this;
        else {
            Destroy(gameObject);
            return;
        }

        Physics2D.IgnoreLayerCollision(11, 11, true);

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (timerRunning)
        {
            HandleTimer();
        }
        else
        {
            currentTime = escapeSeconds;
        }
    }

    public IEnumerator RespawnPlayer(PlayerCharacter2D perso) {
        //TODO: Ajout d'un son pour l'attente  
        yield return new WaitForSeconds(spawnDelay);

        if (FindObjectOfType<AudioManager>() != null)
            FindObjectOfType<AudioManager>().Play("RespawnPlayer");

        perso.gameObject.transform.position = spawnPoint.position;
        perso.gameObject.transform.rotation = spawnPoint.rotation;
        perso.SoinPerso(999999);

        //Detache le grappin si on meurt en etant attache
        if (perso.GetComponent<GrappleBeam>().isGrappleAttached)
        {
            perso.GetComponent<GrappleBeam>().UseGrapple();
        }
      
        //  si le joueur à été écrasé avant de mourir, réactive les controles et remet le scale comme il faut;
        if(perso.gameObject.transform.lossyScale.y < 1.5f)
        {
            Rigidbody2D rbp = perso.GetComponent<Rigidbody2D>() as Rigidbody2D;
            rbp.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

            perso.setEnableInput(true);

            perso.gameObject.transform.localScale = new Vector3(5.0f, 5.0f, 1.0f);
        }

        perso.gameObject.SetActive(true);

        if (playerPrefab != null)
            //Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        if (spawnPrefab != null) {
            Transform clone = Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation) as Transform;
            Destroy(clone.gameObject, 3f);
        }

        perso.joueurStats.immortel = false;
    }

    public void ItemDrop(Ennemis perso)
    {
        float result = UnityEngine.Random.Range(1, 100);
        if (result/100 > 0.5f)
        {
            result = UnityEngine.Random.Range(1, 100);
            if (result/100 > 0.5f)          //1-50: Missile, 51-100: Health
            {
                PlayerCharacter2D pc = FindObjectOfType<PlayerCharacter2D>();
                if (pc.HasUpgrade("Missile"))
                {
                    GameObject clone = Instantiate(itemPickupPrefab, perso.transform.position, perso.transform.rotation);
                    clone.GetComponent<PickupItem>().PickupType = "Missile";
                    clone.GetComponent<Animator>().Play("Missile");
                    clone.GetComponent<PickupItem>().Valeur = 5;
                    //Debug.Log("missile drop");
                }
            }
            else
            {
                //Debug.Log("health drop");
                GameObject clone = Instantiate(itemPickupPrefab, perso.transform.position, perso.transform.rotation);
                clone.GetComponent<PickupItem>().PickupType = "Health";
                clone.GetComponent<Animator>().Play("Health");
                clone.GetComponent<PickupItem>().Valeur = 10;
            }
        }  
    }

    public void HandleTimer()
    {   
        if (timerRunning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                escapeTimer.GetComponent<TextMeshProUGUI>().text = "00:00.00";
                timerRunning = false;
                GameObject.FindWithTag("Player").GetComponent<PlayerCharacter2D>().DommagePerso(10000);
                Invoke("RestartTimer", 2f);
            }
            else
            {
                TimeSpan ts = TimeSpan.FromSeconds(currentTime);
                string txt = Math.Floor(ts.TotalMinutes).ToString("00") + ":" + (Math.Floor(ts.TotalSeconds) % 60).ToString("00") + "." + Math.Floor(ts.TotalMilliseconds) % 100;
                escapeTimer.GetComponent<TextMeshProUGUI>().text = txt;
            }
        }     
    }

    public void RestartTimer()
    {
        instance.currentTime = instance.escapeSeconds;
        timerRunning = true;
    }

    public void ResetEscapeObject(GameObject timer)
    {
        escapeTimer = timer;
        escapeTimer.SetActive(false);
        Cursor.visible = false;
    }

    private void DestroyPlayer(PlayerCharacter2D perso)
    {
        Destroy(perso.gameObject);
    }

    public static void StartEscapeSequence()
    {
        instance.timerRunning = true;

        if(instance.escapeTimer == null)
            instance.escapeTimer = GameObject.FindGameObjectWithTag("EscapeTimerUI");

        instance.escapeTimer.SetActive(true);
        SetSpawnPlayer(GameObject.Find("Node (2)").transform);
        instance.spawnPoint.position = new Vector3(-265, 4, 0);

        List<GameObject> lstCheck = new List<GameObject>(GameObject.FindGameObjectsWithTag("CheckPoint"));
        foreach (GameObject check in lstCheck)
        {
            check.GetComponent<CheckPoint>().EndGameState();
        }

        GameObject egt = GameObject.FindGameObjectWithTag("EndGameTrigger");
        egt.GetComponent<EndGame>().Enable();

        //FindObjectOfType<AudioManager>().Stop("Musique_Jeu");
        // FindObjectOfType<AudioManager>().Play("EscapeMusic");

        if (FindObjectOfType<AudioManager>() != null) {
            FindObjectOfType<AudioManager>().ChangeMusique("EscapeMusic", 0.1f, 0.05f);
        }

        CameraShaker.Instance.StartShake(2f, 1f, 5f);
        instance.StartCoroutine(instance.TypeSentence("Planet destruction imminent. Evacuate immediately!"));
    }

    IEnumerator TypeSentence(string sentence)
    {
        TextMeshProUGUI txt = instance.escapeTimer.transform.Find("EscapeTxt").GetComponent<TextMeshProUGUI>();
        string tmp = "";
        foreach (char letter in sentence.ToCharArray())
        {
            tmp += letter;
            txt.text = tmp;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        yield return new WaitForSecondsRealtime(8f);
        if(txt != null)
            txt.text = "";
    }

    public static void KillJoueur(PlayerCharacter2D perso)
    {
        perso.gameObject.SetActive(false);
        //instance.RespawnPlayer(perso);
        instance.StartCoroutine(instance.RespawnPlayer(perso));
    }

    public static void SetSpawnPlayer(Transform spawn) {
        instance.spawnPoint = spawn;
    }

    public static void KillEnnemi(Ennemis perso)
    {
        instance.ItemDrop(perso);

        //TODO: particule à la mort des ennemis
        Destroy(perso.gameObject);
    }

    public static void KillBoss(boss perso)
    {
        Destroy(perso.gameObject);
    }

    public static void KillBossTP(bossTeleport perso)
    {
        Destroy(perso.gameObject);
    }

    public static void KillCanon(Canon perso) {
        Destroy(perso.gameObject);
    }
}
