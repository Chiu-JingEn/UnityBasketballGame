using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeAction : MonoBehaviour
{
    public Button StartButton;

    // Start is called before the first frame update
    void Start()
    {
        //StartButton = GameObject.Find("StartButton");
        //StartButton.onClick.AddListener(ClickStartButton);
        // SceneManager.LoadScene(0);
    }

    public void ClickStartButton()
    {
        //Debug.Log("Start to scene 0");
        //SceneManager.LoadScene(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
