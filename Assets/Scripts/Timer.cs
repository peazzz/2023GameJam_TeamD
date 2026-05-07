using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Animator EndAnim;
    public static float TimerLeft;
    public bool TimerOn = false;
    public Text TimerTxT;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn && !ProgressBar.GameOver && ProgressBar.START)
        {
            TimerLeft += Time.deltaTime;
            updateTimer(TimerLeft);
        }
        else if(ProgressBar.GameOver)
        {
            EndAnim.SetBool("gameover",true);
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxT.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
