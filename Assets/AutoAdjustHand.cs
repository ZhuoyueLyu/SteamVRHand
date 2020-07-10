using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoAdjustHand : MonoBehaviour
{
    public Slider mySlider;
    public Transform objectAttachedPoint;
    public Transform sphere;
    public Transform sphere2;
    GameObject collidedObject = null;
    Rigidbody col;
    //bool canChange = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "grenade")
    //    {
    //        collidedObject = collision.gameObject;
    //        canChange = true;
    //    }
    //    else {
    //        canChange = false;
    //    }
    //}

    public GameObject FindClosest() {
        GameObject[] grenades = GameObject.FindGameObjectsWithTag("grenade");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = objectAttachedPoint.position;
        foreach (GameObject g in grenades)
        {
            Vector3 diff = g.transform.position - position;
            float curDis = diff.sqrMagnitude;
            if (curDis < distance)
            {
                closest = g;
                distance = curDis;
            }
        }
        return closest;

    }

    // Update is called once per frame
    void Update()
    {
        //if (canChange)
        //{
        //    Debug.Log("we got here");
        //    t += Time.deltaTime / 5;
        //    scale = Mathf.Lerp(mySlider.value, collidedObject.transform.localScale.x, t);
        //    mySlider.value = scale;
        //}

        collidedObject = this.FindClosest();
        col = collidedObject.GetComponent<Rigidbody>();
        Vector3 closestPoint = col.ClosestPointOnBounds(objectAttachedPoint.position);
        sphere.position = closestPoint;
        sphere2.position = objectAttachedPoint.position;
        float dis= Vector3.Distance(closestPoint, objectAttachedPoint.position);
        Debug.Log(collidedObject);
        Debug.Log(dis);
        if (dis <= 0.1) {
            mySlider.value = collidedObject.transform.localScale.x;
        }
    }
}
