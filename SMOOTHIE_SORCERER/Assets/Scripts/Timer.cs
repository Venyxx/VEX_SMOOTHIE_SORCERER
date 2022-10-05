using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI blendStatus;
    public float currentTime;
    public bool hasLimit;
    public float timerLimit;
    // Start is called before the first frame update
    void Start()
    {
        hasLimit = true;
        blendStatus.text = " ";
    }

    // Update is called once per frame
    void Update()
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

 if(currentTime >= timerLimit)
        {
            blendStatus.text = "Overblended";
            blendStatus.color = Color.red;
        }
        else if (currentTime <= 10f)
        {
            
            blendStatus.text = "Well Blended";
            blendStatus.color = Color.green;
        }

    }


    private void SetTimerText()
    {
        timerText.text = currentTime.ToString("0");
    }
}
