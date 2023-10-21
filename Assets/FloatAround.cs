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
    float xSpeed, ySpeed, rotationSpeed;


    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-screenWidth / 2, screenWidth / 2);
        y = Random.Range(-screenHeigh / 2, screenHeigh / 3);

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
        GetComponent<WrapAround>().wrap(ref x, ref y);
        transform.position = new Vector3(x, y, 0);
    }
}
