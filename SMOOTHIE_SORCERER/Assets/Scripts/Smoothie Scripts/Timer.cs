using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI blendStatus;
    public float currentTime;
    public bool startBlending;
    public bool hasLimit;
    public float timerLimit;

    public GameSystem gSys;
    // Start is called before the first frame update
    void Start()
    {
        startBlending = false;
        hasLimit = true;
        blendStatus.text = " ";
        timerText.text = " ";
        gSys = gameObject.GetComponent<GameSystem>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (startBlending == true)
        {
        currentTime = currentTime += Time.deltaTime;

        if (hasLimit && currentTime >= timerLimit)
        {
            currentTime = timerLimit;
            SetTimerText();
            timerText.color = Color.red;
            enabled = false;
        }
        SetTimerText();

 if(currentTime >= 16f )
        {
            blendStatus.text = "Overblended";
            gSys.Score -= 1;
            blendStatus.color = Color.red;
        }
        else if (currentTime >=10f)
        {
            
            blendStatus.text = "Well Blended";
            blendStatus.color = Color.green;
        }

    }
    }


    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }

    public void TimerReset()
    {
       currentTime = 0f;
       blendStatus.text = " ";
    }

    public void TimerStart()
    {
        
        startBlending = true;
    }

    public void TimerStop()
    {  
        startBlending = false;     
    }
}
