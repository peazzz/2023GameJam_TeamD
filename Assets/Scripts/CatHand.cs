using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHand : MonoBehaviour
{
    public GameObject _CatHand;
    public GameObject targetObject;

    public bool Cat1;
    public bool Cat2;
    public bool Cat3;
    public bool Cat4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == targetObject)
                {
                    if (Cat1)
                    {
                        Debug.Log("A");
                        _CatHand.transform.position = new Vector3(_CatHand.transform.position.x + 3, _CatHand.transform.position.y, _CatHand.transform.position.z);
                        Event.touchCount++;
                    }
                    if (Cat2)
                    {
                        Debug.Log("B");
                        _CatHand.transform.position = new Vector3(_CatHand.transform.position.x, _CatHand.transform.position.y, _CatHand.transform.position.z-3);
                        Event.touchCount++;
                    }
                    if (Cat3)
                    {
                        Debug.Log("C");
                        _CatHand.transform.position = new Vector3(_CatHand.transform.position.x, _CatHand.transform.position.y+3, _CatHand.transform.position.z);
                        Event.touchCount++;
                    }
                    if (Cat4)
                    {
                        Debug.Log("D");
                        _CatHand.transform.position = new Vector3(_CatHand.transform.position.x, _CatHand.transform.position.y - 2, _CatHand.transform.position.z);
                        Event.touchCount++;
                    }
                }
            }
        }
    }
}
