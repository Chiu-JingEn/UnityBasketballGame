using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultUI : MonoBehaviour
{
    private Text timeText;
    private Button menu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        timeText = GameObject.Find("time").GetComponent<Text>();
        menu = GameObject.Find("resultMenu").GetComponent<Button>();

        menu.onClick.AddListener(menuOnClick);
        Debug.Log("asaaaaaaaa");
    }
    void menuOnClick()
    {
        Debug.Log("bbbbbbb");
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        timeText.text = (clocker.Instance_.getDuationTime()).ToString() + "s";
    }
    
}
