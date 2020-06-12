using System.Runtime.CompilerServices;
using UnityEngine;
public class clocker
{
    private static clocker singleton;
    private static float startTime=Time.time;

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
    public void resetTime()
    {
        startTime=Time.time;
    }
}