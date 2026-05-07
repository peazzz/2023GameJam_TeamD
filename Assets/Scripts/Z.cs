using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject parentObject;

    public float moveSpeed = 2f;
    public float thresholdDistance = 0.1f;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        GenerateNewTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        if (hit.collider.gameObject == targetObject)
        //        {
        //            Event.Z_Count--;
        //            Destroy(parentObject);
        //        }
        //    }
        //}

        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance < thresholdDistance)
        {
            GenerateNewTargetPosition();
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void GenerateNewTargetPosition()
    {
        float offsetX = Random.Range(-0.2f, 0.2f);
        float offsetY = Random.Range(-0.2f, 0.2f);

        targetPosition = transform.position + new Vector3(offsetX, offsetY, 0);
    }

    public void _Click()
    {
        Event.Z_Count--;
        Destroy(parentObject);
    }
}
