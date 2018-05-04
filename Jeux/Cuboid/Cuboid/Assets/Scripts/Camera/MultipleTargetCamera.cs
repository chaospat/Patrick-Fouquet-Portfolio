﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Camera))]
public class MultipleTargetCamera : MonoBehaviour {

    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = 0.2f;
    public float smoothTimeMultiTarget = 0.5f;

    public float minZoom = 8.0f;
    public float maxZoom = 16.0f;
    public float zoomLimiter = 50.0f;

    private Vector3 velocity;
    public Camera cam;
    private bool searchingForPlayer = false;

    public bool test = false;
    void Start()
    {
        if (targets[0] == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        //TODO: !Faire une vérification pour sélectionner la caméra
        //TODO: !Faire une vérification pour sélectionner le joueur
        //cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (targets[0] == null)
        {
            if (!searchingForPlayer)
            {
                searchingForPlayer = true;
                StartCoroutine(SearchForPlayer());
            }
            return;
        }

        if (targets.Count == 0)
            return;

        if(test)
            offset.x = targets[0].localScale.x;

        Move();
        Zoom();
    }

    void Zoom()
    {
        //Debug.Log(GetGreatestDistance());
        float newZoom = Mathf.Lerp(minZoom, maxZoom, GetGreatestDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        if(targets.Count <=1)
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
        else
            transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTimeMultiTarget);
        
    }

    float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
            return targets[0].position;

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }

    IEnumerator SearchForPlayer()
    {
        GameObject sResult = GameObject.FindGameObjectWithTag("Player");
        if (sResult == null)
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(SearchForPlayer());
        }
        else
        {
            targets[0] = sResult.transform;
            searchingForPlayer = false;
            yield break;
        }
    }
}
