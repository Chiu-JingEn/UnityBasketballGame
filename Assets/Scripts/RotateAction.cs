using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAction : MonoBehaviour
{
    public float RotateSpeed, ShootSpeed;
    public Transform personTran, rotateTran;
    public GameObject Ball, RotateObject;
    public Camera MainCamera;
    private Stack<GameObject> balls = new Stack<GameObject>();
    private GameObject curr_ball;

    // Start is called before the first frame update
    void Start()
    {
        balls.Push(NewBall());
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        RotateCamera();
        KeyActions();
    }

    void KeyActions()
    {
        
        if(Input.GetMouseButtonDown(0))
        {
            ShootBall(ref curr_ball);
            balls.Push(NewBall());
        }
    }

    void RotateCamera()
    {
        const float limitAngle = 90.0f;
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");
        
        Vector3 personRot = personTran.transform.localEulerAngles;
        Vector3 rotateRot = rotateTran.transform.localEulerAngles;
        //Vector3 mainCamRot = MainCamera.transform.localEulerAngles;

        float RotateX = MouseX * RotateSpeed;
        float RotateY = MouseY * RotateSpeed;

        personRot.y += RotateX;
        rotateRot.x -= RotateY;
        
        if (rotateRot.x >= limitAngle && rotateRot.x <= 90)
            rotateRot.x = limitAngle;
        
        if (rotateRot.x <= 360.0f-limitAngle && rotateRot.x>90)
            rotateRot.x = 360.0f - limitAngle;
        

        personTran.transform.localEulerAngles = new Vector3(personRot.x, personRot.y, 0);
        rotateTran.transform.localEulerAngles = new Vector3(rotateRot.x, rotateRot.y, 0);
        //MainCamera.transform.localEulerAngles = new Vector3(mainCamRot.x, mainCamRot.y, 0);
    }

    GameObject NewBall()
    {
        GameObject new_ball = Instantiate(Ball, RotateObject.transform);
        Rigidbody rigidbody = new_ball.GetComponent<Rigidbody>();
        Collider collider = new_ball.GetComponent<Collider>();
        new_ball.name = "Ball_" + balls.Count;

        collider.isTrigger = true;
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
        curr_ball = new_ball;

        return new_ball;
    }

    void ShootBall(ref GameObject ball)
    {
        Rigidbody rigidbody = ball.GetComponent<Rigidbody>();
        Collider collider = ball.GetComponent<Collider>();

        rigidbody.velocity = RotateObject.transform.forward * ShootSpeed;
        collider.isTrigger = false;
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
        ball.transform.SetParent(null);
    }
}
