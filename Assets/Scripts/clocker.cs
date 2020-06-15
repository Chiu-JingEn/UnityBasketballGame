using System.Runtime.CompilerServices;
using UnityEngine;
public class clocker
{
    private static clocker singleton;
    private static float startTime=Time.time;
    private static float timer = 0f;

    public static clocker Instance_
    {
        get
        {
            if (singleton == null)
            {
                singleton = new clocker();
            }

            return singleton;
        }
    }
    public int getTime()
    {
        return (int)(Time.time - startTime);
    }
    public float getDuationTime()
    {
        return timer;
    }
    public void updateDuationTime()
    {
        timer += Time.deltaTime;
    }
    public void punishDuationTime()
    {
        timer += 2f;
    }
    public void resetTime()
    {
        startTime=Time.time;
        timer = 0f;
    }
}