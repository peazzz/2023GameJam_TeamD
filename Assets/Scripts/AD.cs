using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AD : MonoBehaviour
{
    public void _Cancel()
    {
        Event.ADCount--;
        Destroy(gameObject);
    }
}
