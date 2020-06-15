using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GaneOver : MonoBehaviour
{

    public Button menu;
    public Button continue_;
    // Start is called before the first frame update
    void Start()
    {
        menu = GameObject.Find("Menu").GetComponent<Button>();
        continue_ = GameObject.Find("Continue_").GetComponent<Button>();
        menu.onClick.AddListener(menuOnClick);
        continue_.onClick.AddListener(continueOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void menuOnClick()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
    void continueOnClick()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
