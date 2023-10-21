using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    float rotationSpeed = 50;

    [SerializeField]
    float speed = 10f;      //speed we will travel when not landed

    [SerializeField]
    float screenHeigh = 480;

    [SerializeField]
    float screenWidth = 620;

    GameObject myMoon;
    bool bLanded = false;
    float minX, maxX, minY, maxY;

    // Start is called before the first frame update
    void Start()
    {
        minX = -screenWidth / 2;
        maxX = screenWidth / 2;
        minY = -screenHeigh / 2;
        maxY = screenHeigh / 2;

        //find a moon and attach to it.
        myMoon = GameObject.FindGameObjectWithTag("Moon");
        transform.position = myMoon.transform.position;
        bLanded = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //destroy the moon
            Destroy(myMoon);

            bLanded = false;
        }

        if (bLanded)
        {
            transform.position = myMoon.transform.position;
        }
        else
        {

            transform.Translate(speed * Time.deltaTime * transform.right, Space.World);

            var x = transform.position.x;
            var y = transform.position.y;

            GetComponent<WrapAround>().wrap(ref x, ref y);

            transform.position = new Vector3(x, y, 0);

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Moon"))
        {
            myMoon = collision.gameObject;
            bLanded = true;
        }
    }
}
