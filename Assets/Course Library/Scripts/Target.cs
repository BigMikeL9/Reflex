using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManagerScript; // This is a reference variable for our Game Manager.
    public ParticleSystem explosionParticle;

    public float minSpeed = 12;
    public float maxSpeed = 16;
    public float maxTorque = 10;
    private float xRange = 4;
    private float yRange = 1;

    public int pointValue;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>(); // Here we are finding the GameManager Script in the Game Manager GameObject.

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque());

        transform.position = RandomSpawnPos();

    }

    // Update is called once per frame
    void Update()
    {

    }

    //A method inwhich whenever you click your mouse while hovering over a gameobject with a collider, a line of code will trigger.
    private void OnMouseDown()
    {
        if (gameManagerScript.isGameActive)
        {
            Destroy(gameObject);
            gameManagerScript.ScoreUpdate(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManagerScript.GameOver();
        }
    }

    //This is called a "method". Things between Parentheses are called "Parameters".
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -yRange);
    }

}
