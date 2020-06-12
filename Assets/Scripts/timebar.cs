using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
public class timebar : MonoBehaviour
{
    //private clocker mytime;
    private Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("time").GetComponent<Text>();
        //mytime = clocker.Instance_;
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = clocker.Instance_.getTime().ToString()+"s";
        //Debug.Log(mytime.getTime().ToString());
    }
}
