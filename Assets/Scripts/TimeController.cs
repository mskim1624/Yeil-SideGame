using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool isCountDown = true;
    public float gameTime = 0f;
    public bool isTimeOver = false; // true => 타이머 정지
    public float displayTime = 0f;  // 표시 시간

    float curTime = 0f;             // 현재 시간

    // Start is called before the first frame update
    void Start()
    {
        if (isCountDown)
        {
            displayTime = gameTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeOver == false)
        {
            curTime += Time.deltaTime;
            Debug.Log("CURTIME:" + curTime);
            if (isCountDown)
            {
                displayTime = gameTime - curTime;
                if (displayTime <= 0.0f)
                {
                    displayTime = 0.0f;
                    isTimeOver = true;
                }
            }
            else
            {
                displayTime = curTime;
                if(displayTime >= gameTime)
                {
                    displayTime = gameTime;
                    isTimeOver = true;
                }
            }
            Debug.Log("TIMES:" + displayTime);
        }
    }
}
