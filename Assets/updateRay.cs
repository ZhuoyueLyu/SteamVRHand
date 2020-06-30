using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateRay : MonoBehaviour
{
    public Transform indexFingerPos;
    public Transform sliderHandlePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(indexFingerPos.position, sliderHandlePos.position);
        Debug.Log(distance);
        CurvedUIInputModule.CustomControllerRay = new Ray(indexFingerPos.position, indexFingerPos.forward);
        if (distance < 0.01)
        {
            Debug.Log("is true!");
            CurvedUIInputModule.CustomControllerButtonState = true;
        }
        else {
            CurvedUIInputModule.CustomControllerButtonState = false;
        }
        
    }

}
