using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flipSprite : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var randomInt = Random.Range(0, 100);
        if (randomInt < 1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }

        else
            transform.localRotation = Quaternion.Euler(0, 0, 0);

    }
}
