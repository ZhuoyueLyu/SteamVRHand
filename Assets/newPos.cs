using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newPos : MonoBehaviour
{   public Transform handleNew;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = handleNew.position-handleNew.forward*0.01f;
    }
}
