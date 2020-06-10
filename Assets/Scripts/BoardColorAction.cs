using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardColorAction : MonoBehaviour
{
    public Material originColor;
    public Material getScoreColor;
    public int times = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (BasketAction.getScore)
        {
            StartCoroutine(getScoreAction());
            BasketAction.getScore = false;
        }
    }

    IEnumerator getScoreAction()
    {
        for (int i = 0; i < times; i++)
        {
            GetComponent<MeshRenderer>().material = getScoreColor;
            yield return new WaitForSecondsRealtime(0.1f);
            GetComponent<MeshRenderer>().material = originColor;
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}

