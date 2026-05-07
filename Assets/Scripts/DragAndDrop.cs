using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool power;
    public bool Z;
    private Vector3 mousePosition;
    public GameObject PowerOn_Audio;

    void Update()
    {
        if (power && Event.Power_Out)
        {
            transform.position = new Vector3(transform.position.x, -3.5f, transform.position.z);
            if (transform.position.x > -26.5f)
            {
                transform.position = new Vector3(-26.5f, transform.position.y, transform.position.z);
                Event.Power_Out = false;
                Instantiate(PowerOn_Audio, transform.position, Quaternion.identity);
            }
            else if (transform.position.x < -30)
            {
                transform.position = new Vector3(-30, transform.position.y, transform.position.z);
            }
        }

        if (ProgressBar.GameOver)
        {
            transform.position = new Vector3(-26.5f, transform.position.y, transform.position.z);
            Event.Power_Out = false;
        }
    }

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();        
    }

    private void OnMouseDrag()
    {
        if (power && Event.Power_Out)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        }
    }
}
