using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class RotateAction : MonoBehaviour
{
    public float RotateSpeed, ShootSpeed;
    public Transform personTran, rotateTran;
    public GameObject Ball, RotateObject;
    public Camera MainCamera;
    private Stack<GameObject> balls = new Stack<GameObject>();
    private GameObject curr_ball;
    public int timer_power=0;
    public float time_power_f=0f;
    public int power_positive_controler=1;
    private Image barImageNumber;
    private GameObject powerBar;
    private void Awake()
    {

        barImageNumber = GameObject.Find("bar").GetComponent<Image>();
        powerBar = GameObject.Find("PowerBar");
        powerBar.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        balls.Push(NewBall());
        
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        RotateCamera();
        KeyActions();
    }

    void KeyActions()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    ShootBall(ref curr_ball);
        //    balls.Push(NewBall());
        //}
        //按住蓄力
        if (Input.GetKey(KeyCode.Mouse0))
        {
            powerBar.SetActive(true);
            barImageNumber.fillAmount = time_power_f;
            time_power_f += Time.deltaTime* power_positive_controler;
            if(time_power_f>=1)
            {
                time_power_f = 1.0f;
                power_positive_controler = -1;
            }
            else if(time_power_f<=0)
            {
                time_power_f = 0.0f;
                power_positive_controler = 1;
            }
            
        }
        //放開射出
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            powerBar.SetActive(false);
            timer_power = (int)time_power_f;
            time_power_f = 0.0f;
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

        rigidbody.velocity = RotateObject.transform.forward * ShootSpeed* barImageNumber.fillAmount;
        collider.isTrigger = false;
        rigidbody.useGravity = true;
        rigidbody.isKinematic = false;
        ball.transform.SetParent(null);
    }
}
