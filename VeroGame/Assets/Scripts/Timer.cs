using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public delegate void TimeUpFuncition();

    private static float timeLeft = 0;
    private static bool timerRunning = false;
    private static TimeUpFuncition upCall;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if(timerRunning)
        {
            timeLeft -= Time.deltaTime;
            print(timeLeft);
            if(timeLeft <= 0)
            {
                timeUp();
                timeLeft = 0.0f;
                timerRunning = false;
            }
        }
		
	}

    public static float getLeftTime()
    {
        return timeLeft;
    }

    public static void setTimer(float time, TimeUpFuncition method)
    {
        timeLeft = time;
        timerRunning = true;
        upCall = method;
    }

    public static void stopTimer()
    {
        timerRunning = false;
    }

    public static void kill()
    {
        print("OVER");
    }

    public static void timeUp()
    {
        timerRunning = false;
        upCall();
    }

    public static string getTimeLeftString()
    {
        return "null";
    }
}
