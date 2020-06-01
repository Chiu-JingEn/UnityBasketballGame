using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class BasketAction : MonoBehaviour
{
    public int score_per_ball = 100;
    public static int score = 0;
    static bool upCollider = false;
    static bool downCollider = false;
    static bool isUpFirst = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball" && tag == "UpCollider")
        {
            upCollider = true;
        }

        if (other.tag == "Ball" && tag == "DownCollider" && upCollider)
        {
            score += score_per_ball;
            isUpFirst = false;
            upCollider = false;
            downCollider = false;
            Debug.Log(score);
            //增加跳場景
            if (score >= 500)
            {
                if(Application.loadedLevel+1< Application.levelCount)
                {
                    Application.LoadLevel(Application.loadedLevel + 1);
                    score = 0;
                }
            }
        }
    }
}
