using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BasketAction : MonoBehaviour
{
    public int score_per_ball = 100;
    public static int score = 0;
    static bool upCollider = false;
    static bool downCollider = false;
    static bool isUpFirst = false;
    private Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.Find("score").GetComponent<Text>();
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
            scoreText.text = score.ToString();
            //增加跳場景
            if (score >= 300)
            {
                //Debug.Log(SceneManager.GetActiveScene().buildIndex);
                //Debug.Log(SceneManager.sceneCount);
                if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                    score = 0;
                }
            }
        }
    }
}
