using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 50;

    [SerializeField]
    float speed = 10f;      //speed we will travel when not landed

    GameObject myMoon;
    bool bLanded = false;

    // Start is called before the first frame update
    void Start()
    {
        //find a moon and attach to it.
        myMoon = GameObject.FindGameObjectWithTag("Moon");
        bLanded = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        if (bLanded)
        {
            transform.position = myMoon.transform.position;
        }
    }
}
