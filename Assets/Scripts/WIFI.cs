using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WIFI : MonoBehaviour
{
    public GameObject Wifi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Event.Wifi_X)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == Wifi)
                {
                    Wifi.SetActive(false);
                    Event.Wifi_X = false;
                    Event.WifiTime = 0;
                }
            }
        }
    }
}
