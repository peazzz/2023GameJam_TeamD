using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    [Header("電源")]
    public GameObject Power;
    private float _PowerTime;
    public static bool Power_Out;
    public GameObject Power_particle;
    private Vector3 Power_particle_Spawn;
    public GameObject Power_particle2;
    private Vector3 Power_particle2_Spawn;
    private float _PowerOutTime;
    public GameObject Power_Audio;
    public Transform plugHead;

    [Header("睡覺")]
    private float _ZZZTime;
    public GameObject Z;
    public static int Z_Count;
    private GameObject Z_object;
    public GameObject ZZZ_Audio;

    [Header("貓手")]
    public GameObject CatHand;
    private float _CatHandTime;
    private Vector3 EndPoint;
    private Vector3 StartPoint;
    public Animator Cat_Anim;
    public static int touchCount;
    public static bool Trouble;
    private bool isBack;
    private int _random;
    private bool inTrouble;
    public GameObject Cat1_Audio;

    [Header("貓手2")]
    public GameObject CatHand2;
    private Vector3 EndPoint2;
    private Vector3 StartPoint2;
    public Animator Cat2_Anim;
    public GameObject Cat2_Audio;

    [Header("貓手3")]
    public GameObject CatHand3;
    private Vector3 EndPoint3;
    private Vector3 StartPoint3;
    public Animator Cat3_Anim;
    public GameObject Cat3_Audio;

    [Header("貓手4")]
    public GameObject CatHand4;
    private Vector3 EndPoint4;
    private Vector3 StartPoint4;
    public Animator Cat4_Anim;
    public GameObject Cat4_Audio;

    [Header("廣告")]
    public GameObject AD_parent;
    public GameObject[] ad;
    public float AD_SpawnTime;
    private GameObject AD_object;
    public static bool haveAD;
    public static float ADCount;
    public GameObject AD_Audio;

    [Header("蚊子")]
    public GameObject Mosquito;
    public GameObject Mosquito_object;
    public Transform MosquitoSpawn_point;
    public float MosquitoSpawnTime;
    public static int MosquitoCount;
    public GameObject Mosquito_Audio;

    [Header("WIFI")]
    public GameObject wifi;
    public static float WifiTime;
    public static bool Wifi_X;
    public GameObject WifiOut_Audio;

    // Start is called before the first frame update
    void Start()
    {
        EndPoint = new Vector3(25, 0, 25);
        StartPoint = new Vector3(45, 0, 25);
        EndPoint2 = new Vector3(3, 0, 10);
        StartPoint2 = new Vector3(3, 0, -10);
        EndPoint3 = new Vector3(-14, 20, 25);
        StartPoint3 = new Vector3(-14, 55, 25);
        EndPoint4 = new Vector3(0.2f, 1.3f, 36);
        StartPoint4 = new Vector3(0.2f, -10, 36);
        Power_particle_Spawn = new Vector3(-8f, -5.8f, 31.1f);
        Power_particle2_Spawn = new Vector3(-12f, -5.8f, 31.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!ProgressBar.GameOver && ProgressBar.START)
        {
            _power();
            _Zzz();
            _AD();
            _Mosquito();
            _WIFI();
        }
        else
        {
            if (Z_object != null)
            {
                Destroy(Z_object);
            }
            if (AD_object != null)
            {
                Destroy(AD_object);
            }
            if (Mosquito_object != null)
            {
                Destroy(Mosquito_object);
            }
            wifi.SetActive(false);
            inTrouble = false;
            isBack = false;
            touchCount = 0;
            if (_random == 1)
            {
                CatHand.transform.position = Vector3.Lerp(CatHand.transform.position, StartPoint, 0.02f);
                Cat_Anim.SetBool("CatHand", false);
            }
            else if (_random == 2)
            {
                CatHand2.transform.position = Vector3.Lerp(CatHand2.transform.position, StartPoint2, 0.02f);
                Cat2_Anim.SetBool("CatHand", false);
            }
            else if (_random == 3)
            {
                CatHand3.transform.position = Vector3.Lerp(CatHand3.transform.position, StartPoint3, 0.02f);
                Cat3_Anim.SetBool("CatHand", false);
            }
            else if (_random == 4)
            {
                CatHand4.transform.position = Vector3.Lerp(CatHand4.transform.position, StartPoint4, 0.02f);
                Cat4_Anim.SetBool("CatHand", false);
            }
        }
    }

    void FixedUpdate()
    {
        if (!ProgressBar.GameOver && ProgressBar.START)
        {
            _CatHand();
        }
    }

    void _power()
    {
        if (!Power_Out)
        {
            _PowerTime += Time.deltaTime;
            _PowerOutTime = 0;
        }
        else
        {
            _PowerOutTime += Time.deltaTime;
        }

        if (_PowerTime >= 8)
        {
            Instantiate(Power_Audio, transform.position, Quaternion.identity);
            Instantiate(Power_particle, plugHead.position, Quaternion.identity);
            Power.transform.position = new Vector3(-30, -3.5f, 26);
            Power_Out = true;
            _PowerTime = 0;
        }

        if (_PowerOutTime > 1.5f)
        {
            Instantiate(Power_particle2, plugHead.position, Quaternion.identity);
            _PowerOutTime = 0;
        }
    }

    void _Zzz()
    {
        _ZZZTime += Time.deltaTime;
        if (_ZZZTime > 3.5f && Z_Count<5)
        {
            Z_Count++;
            _ZZZTime = 0;
            Instantiate(ZZZ_Audio, transform.position, Quaternion.identity);
            Z_object = Instantiate(Z, AD_parent.transform);
            RectTransform rectTransform = Z_object.GetComponent<RectTransform>();

            float randomX = Random.Range(-640, 640);
            float randomY = Random.Range(-140, 310);

            rectTransform.anchoredPosition = new Vector2(randomX, randomY);
        }
    }

    void _CatHand()
    {
        if(!isBack)
        {
            _CatHandTime += Time.deltaTime;
        }
        
        if (_CatHandTime >= 6)
        {
            if (!inTrouble)
            {
                _random = Random.Range(1, 5);
            }
            switch (_random)
            {
                case 1:
                    if (!inTrouble)
                    {
                        Instantiate(Cat1_Audio, transform.position, Quaternion.identity);
                    }
                    inTrouble = true;
                    CatHand.transform.position = Vector3.Lerp(CatHand.transform.position, EndPoint, 0.02f);
                    if (CatHand.transform.position.x < 26)
                    {
                        Cat_Anim.SetBool("CatHand", true);
                        Trouble = true;
                    }
                    else
                    {
                        Cat_Anim.SetBool("CatHand", false);
                        Trouble = false;
                    }
                    break;
                case 2:
                    if (!inTrouble)
                    {
                        Instantiate(Cat2_Audio, transform.position, Quaternion.identity);
                    }
                    inTrouble = true;
                    CatHand2.transform.position = Vector3.Lerp(CatHand2.transform.position, EndPoint2, 0.02f);
                    if (CatHand2.transform.position.z > -21)
                    {
                        Cat2_Anim.SetBool("CatHand", true);
                        Trouble = true;
                    }
                    else
                    {
                        Cat2_Anim.SetBool("CatHand", false);
                        Trouble = false;
                    }
                    break;
                case 3:
                    if (!inTrouble)
                    {
                        Instantiate(Cat3_Audio, transform.position, Quaternion.identity);
                    }
                    inTrouble = true;
                    CatHand3.transform.position = Vector3.Lerp(CatHand3.transform.position, EndPoint3, 0.02f);
                    if (CatHand3.transform.position.y < 21)
                    {
                        Cat3_Anim.SetBool("CatHand", true);
                        Trouble = true;
                    }
                    else
                    {
                        Cat3_Anim.SetBool("CatHand", false);
                        Trouble = false;
                    }
                    break;
                case 4:
                    if (!inTrouble)
                    {
                        Instantiate(Cat4_Audio, transform.position, Quaternion.identity);
                    }
                    inTrouble = true;
                    CatHand4.transform.position = Vector3.Lerp(CatHand4.transform.position, EndPoint4, 0.02f);
                    if (CatHand4.transform.position.y > 0.3f)
                    {
                        Cat4_Anim.SetBool("CatHand", true);
                        Trouble = true;
                    }
                    else
                    {
                        Cat4_Anim.SetBool("CatHand", false);
                        Trouble = false;
                    }
                    break;
            }
        }

        if (touchCount >= 5 && !isBack)
        {
            _CatHandTime = 0;
            isBack = true;               
        }

        if (isBack)
        {
            switch (_random)
            {
                case 1:
                    CatHand.transform.position = Vector3.Lerp(CatHand.transform.position, StartPoint, 0.02f);
                    if (CatHand.transform.position.x > 44)
                    {
                        inTrouble = false;
                        isBack = false;
                        touchCount = 0;
                    }
                    break;
                case 2:
                    CatHand2.transform.position = Vector3.Lerp(CatHand2.transform.position, StartPoint2, 0.02f);
                    if (CatHand2.transform.position.z < -39)
                    {
                        inTrouble = false;
                        isBack = false;
                        touchCount = 0;
                    }
                    break;
                case 3:
                    CatHand3.transform.position = Vector3.Lerp(CatHand3.transform.position, StartPoint3, 0.02f);
                    if (CatHand3.transform.position.y > 54)
                    {
                        inTrouble = false;
                        isBack = false;
                        touchCount = 0;
                    }
                    break;
                case 4:
                    CatHand4.transform.position = Vector3.Lerp(CatHand4.transform.position, StartPoint4, 0.02f);
                    if (CatHand4.transform.position.y < -9)
                    {
                        inTrouble = false;
                        isBack = false;
                        touchCount = 0;
                    }
                    break;
            }
        }
    }

    void _AD()
    {
        AD_SpawnTime += Time.deltaTime;

        if (AD_SpawnTime > 4 && ADCount<4)
        {
            Instantiate(AD_Audio, transform.position, Quaternion.identity);
            ADCount++;
            int randomAD = Random.Range(0, ad.Length);
            AD_object = Instantiate(ad[randomAD], AD_parent.transform);

            RectTransform rectTransform = AD_object.GetComponent<RectTransform>();

            float randomX = Random.Range(-640, 600);
            float randomY = Random.Range(-140, 280);

            rectTransform.anchoredPosition = new Vector2(randomX, randomY);
            AD_SpawnTime = 0;
        }

        if (AD_object != null)
        {
            haveAD = true;
        }
        else
        {
            haveAD = false;
        }
    }

    void _Mosquito()
    {
        MosquitoSpawnTime += Time.deltaTime;
        if (MosquitoSpawnTime >= 7 && MosquitoCount<5)
        {
            Instantiate(Mosquito_Audio, transform.position, Quaternion.identity);
            MosquitoCount++;
            Mosquito_object = Instantiate(Mosquito, MosquitoSpawn_point.position, Quaternion.identity);
            MosquitoSpawnTime =0;
        }
    }

    void _WIFI()
    {
        if (!Wifi_X)
        {
            WifiTime += Time.deltaTime;
        }

        if (WifiTime >= 10 && !Wifi_X)
        {
            Instantiate(WifiOut_Audio, transform.position, Quaternion.identity);
            wifi.SetActive(true);
            Wifi_X = true;
        }
    }
}
