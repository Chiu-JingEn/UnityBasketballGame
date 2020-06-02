using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Triger: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
    void OnParticleCollision(GameObject other)
    {
        //Debug.Log("particle Triger: " + other.name);
        if (other.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
