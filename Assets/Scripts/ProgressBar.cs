using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ProgressBar : MonoBehaviour
{
    public Slider progress;
    public Animator LHand;
    public Animator RHand;
    public static bool GameOver;
    private float Random_type;
    public GameObject TimeFrame;
    public GameObject Restart;
    public Animator EndAnim;
    public VideoPlayer videoPlayer;
    private bool hit;
    private float hitTime;
    public AudioSource Typing_Audio;
    public static bool START;
    public GameObject Hint;
    public GameObject LOGO;
    public GameObject Start_BG;

    public GameObject End_Audio;
    public GameObject Start_Audio;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetMouseButtonDown(0)) && !START)
        {
            START = true;
            Hint.SetActive(false);
            LOGO.SetActive(false);
            Start_BG.SetActive(false);
            Instantiate(Start_Audio, transform.position, Quaternion.identity);
        }

        if (GameOver)
        {
            Typing_Audio.Pause();
        }

        if (!GameOver && START)
        {
            _Click();


            if (Input.GetKeyDown(KeyCode.A))
            {
                Random_type = Random.Range(1, 3);
                hit = true;
                hitTime = 0.5f;
                switch (Random_type)
                {
                    case 1:
                        LHand.SetTrigger("type");
                        break;
                    case 2:
                        LHand.SetTrigger("type2");
                        break;
                }
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Random_type = Random.Range(1, 3);
                hit = true;
                hitTime = 0.5f;
                switch (Random_type)
                {
                    case 1:
                        RHand.SetTrigger("type");
                        break;
                    case 2:
                        RHand.SetTrigger("type2");
                        break;
                }
            }

            if (progress.value >= 0.99f && !GameOver)
            {
                Instantiate(End_Audio, transform.position, Quaternion.identity);
                GameOver = true;
                TimeFrame.SetActive(true);
                Restart.SetActive(true);
                
            }

            if (hitTime > 0 && hit)
            {
                hitTime -= Time.deltaTime;
                if (hitTime <= 0)
                {
                    hit = false;
                }
                videoPlayer.Play();
                if (!Typing_Audio.isPlaying)
                {
                    Typing_Audio.Play();
                }
            }
            else
            {
                videoPlayer.Pause();
                Typing_Audio.Pause();
            }
        }       
    }

    void _Click()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && (!Event.Power_Out && Event.Z_Count >= 5 && !Event.Trouble))
        {
            progress.value += 0f;
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && (!Event.Power_Out && Event.Z_Count >= 1 && !Event.Trouble))
        {
            progress.value += 0.005f;
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            progress.value += 0.01f;
        }
       
        if (Event.Power_Out && Event.Trouble)
        {
            progress.value -= Time.deltaTime * 0.05f;
        }
        else if (Event.Power_Out || Event.Trouble)
        {
            progress.value -= Time.deltaTime * 0.025f;
        }
        else
        {
            progress.value -= Time.deltaTime * 0.005f;
        }
        
        if (Event.haveAD)
        {
            progress.value -= Time.deltaTime * 0.02f;
        }

        if (Event.MosquitoCount>=1)
        {
            progress.value -= Time.deltaTime * 0.01f * Event.MosquitoCount;
        }

        if (Event.Wifi_X)
        {
            progress.value -= Time.deltaTime * 0.05f;
        }
    }

    public void _ReStart()
    {
        GameOver = false;
        Event.Power_Out = false;
        Event.Z_Count = 0;
        Event.ADCount = 0;
        Event.touchCount = 0;
        Event.Trouble = false;
        Event.haveAD = false;
        Event.MosquitoCount = 0;
        Event.WifiTime = 0;
        Event.Wifi_X = false;
        progress.value = 0;
        EndAnim.SetBool("gameover", false);
        TimeFrame.SetActive(false);
        Restart.SetActive(false);
        Timer.TimerLeft = 0;
    }
}
