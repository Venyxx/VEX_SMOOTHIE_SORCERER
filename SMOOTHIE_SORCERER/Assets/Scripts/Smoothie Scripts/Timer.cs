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

    public GameSystem GameSystem;
    public GameSystem gSys;
    // Start is called before the first frame update
    void Start()
    {
        startBlending = false;
        hasLimit = true;
        blendStatus.text = " ";
        timerText.text = " ";
        gSys = GameSystem.GetComponent<GameSystem>();
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
                Overblended();
        }
        else if (currentTime >=10f)
        {
                WellBlended();
        }

    }
    }


    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }

    public void TimerStart()
    {

        if (startBlending == true)
        {
            startBlending = false;
        }
        else
        {
            currentTime = 0f;
            startBlending = true;
        }
    }

    public void WellBlended()
    {
        blendStatus.text = "Well Blended";
        blendStatus.color = Color.green;
    }

   

    public void Overblended()
    {
        blendStatus.text = "Overblended";
        gSys.Score -= 1;
        blendStatus.color = Color.red;
    }
}
