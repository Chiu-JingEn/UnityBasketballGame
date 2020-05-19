using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float Speed = 0.5f;
    public Animation anim;
    public Camera eye, mainCamera;
    public GameObject Head;

    private bool isWalk = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        eye.enabled = false;
        //Head.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        isWalk = false;

        KeyActions();

        if (isWalk && !anim.isPlaying)
        {
            anim.Play("Walk");
        }
        else if (!isWalk)
        {
            anim.Stop("Walk");
        }
    }    

    void KeyActions()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            isWalk = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            isWalk = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
            isWalk = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            isWalk = true;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            eye.enabled = !eye.enabled;
            mainCamera.enabled = !mainCamera.enabled;
            //Head.GetComponent<Renderer>().enabled = !Head.GetComponent<Renderer>().enabled;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.Play("Jump");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Destroy")
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }
}
