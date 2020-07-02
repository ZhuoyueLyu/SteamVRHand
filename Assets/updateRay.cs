using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updateRay : MonoBehaviour
{
    public Transform indexFinger;
    public Transform sliderHandle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(indexFinger.position, sliderHandle.position);
        Vector3 rayOrigin = sliderHandle.position - sliderHandle.forward * 0.01f;
        Vector3 rayDirection = sliderHandle.forward;
        CurvedUIInputModule.CustomControllerRay = new Ray(rayOrigin, rayDirection);


        if (distance < 0.01)
        {
            CurvedUIInputModule.CustomControllerButtonState = true;
            Vector3 originAndIndexFinger = indexFinger.position - rayOrigin;
            var horizontalLength = Vector3.Dot(originAndIndexFinger, rayDirection);
            Vector3 horizontalVector = Mathf.Sqrt(horizontalLength) * rayDirection;
            Vector3 perpendicularVector = originAndIndexFinger - horizontalVector;
            CurvedUIInputModule.CustomControllerRay = new Ray(rayOrigin+ perpendicularVector, rayDirection);

        }
        else {
            CurvedUIInputModule.CustomControllerButtonState = false;
        }
        
    }

}
