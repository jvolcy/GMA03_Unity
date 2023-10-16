using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatAround : MonoBehaviour
{
    [SerializeField]
    float rotationSpeedRange = 90f;

    [SerializeField]
    float maxVelocity = 50f;

    [SerializeField]
    float screenHeigh = 480;

    [SerializeField]
    float screenWidth = 620;

    float x = 0, y = 0;
    float minX, maxX, minY, maxY;
    float xSpeed, ySpeed, rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        minX = -screenWidth/2;
        maxX = screenWidth/2;
        minY = -screenHeigh/2;
        maxY = screenHeigh/2;

        x = Random.Range(minX, maxX);
        y = Random.Range(minY, maxY);

        xSpeed = Random.Range(-maxVelocity, maxVelocity);
        ySpeed = Random.Range(-maxVelocity, maxVelocity);
        rotationSpeed = Random.Range(-rotationSpeedRange, rotationSpeedRange);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

        x += xSpeed * Time.deltaTime;
        y += ySpeed * Time.deltaTime;

        if (x > maxX)
        {
            x -= screenWidth;
        }

        if (x < minX)
        {
            x += screenWidth;
        }

        if (y > maxY)
        {
            y -= screenHeigh;
        }

        if (y < minY)
        {
            y += screenHeigh;
        }

        transform.position = new Vector3(x, y, 0);
    }
}
