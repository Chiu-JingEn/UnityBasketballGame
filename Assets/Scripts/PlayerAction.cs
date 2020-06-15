using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerAction : MonoBehaviour
{
    public float Speed = 0.5f;
    public Animation anim;
    public Camera eye, mainCamera;
    public GameObject Head;
    public GameObject Person;
    private Vector3 personInitPos = new Vector3(0, 0, 0);
    private bool isWalk = false;
    public GameObject _GameOver;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.enabled = true;
        eye.enabled = false;
        Person = GameObject.Find("Person");
        personInitPos = Person.transform.position;
        //Head.GetComponent<Renderer>().enabled = true;
        if (SceneManager.GetActiveScene().buildIndex==1)
        {
            clocker.Instance_.resetTime();
        }
        if (_GameOver!=null)
        {
            _GameOver.SetActive(false);
        }
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
            transform.position = personInitPos;
        }
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Destroy")
        {
            transform.position = personInitPos;
            
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            clocker.Instance_.punishDuationTime();
            _GameOver.SetActive(true);
        }
    }
}
