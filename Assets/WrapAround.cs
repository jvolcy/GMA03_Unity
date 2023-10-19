using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
    [SerializeField]
    float minX = -320, maxX = 320, minY = -240, maxY = 240;


    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;

        if (x > maxX)
        {
            x = minX;
        }

        if (x < minX)
        {
            x = maxX;
        }

        if (y > maxY)
        {
            y = minY;
        }

        if (y < minY)
        {
            y = maxY;
        }

        transform.position = new Vector3(x, y, 0);
    }
}
