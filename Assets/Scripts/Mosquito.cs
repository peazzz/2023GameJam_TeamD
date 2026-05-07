using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MonoBehaviour
{
    private float minX = -14;
    private float minY = -2;
    private float maxX = 15;
    private float maxY = 9;
    public GameObject targetObject;
    public float _MosquitoTime;
    private Vector3 targetPosition;
    public GameObject Hit_Audio;

    // Start is called before the first frame update
    void Start()
    {
        GenerateNewTargetPosition();
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
                    Instantiate(Hit_Audio, transform.position, Quaternion.identity);
                    Event.MosquitoCount--;
                    Destroy(this.gameObject);
                }
            }
        }         

        transform.position = Vector3.Lerp(transform.position, targetPosition, 1.5f * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance < 1)
        {
            GenerateNewTargetPosition();
        }
    }

    void GenerateNewTargetPosition()
    {
        float offsetX = Random.Range(minX, maxX);
        float offsetY = Random.Range(minY, maxY);

        targetPosition = new Vector3(offsetX, offsetY, 26);
    }
}
