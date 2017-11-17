using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    public GameObject pivot;

    private GameObject initTransform;
    private GameObject tempTransform;

    public float horizontalAngle;

    // Use this for initialization
    void Start () {
        initTransform = new GameObject("LigtInitTransform");
        initTransform.transform.position = new Vector3(0, 2, -8);
        tempTransform = new GameObject("LightTempTransform");
        tempTransform.transform.position = initTransform.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        

    }

    public void setHAngle(float value)
    {
        horizontalAngle = value;

        tempTransform.transform.position = initTransform.transform.position;
        tempTransform.transform.rotation = initTransform.transform.rotation;

        tempTransform.transform.RotateAround(pivot.transform.position, Vector3.up, horizontalAngle * 360);

        this.transform.position = tempTransform.transform.position;
        this.transform.rotation = tempTransform.transform.rotation;
    }

    //public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    //{
    //    Vector3 dir = point - pivot; // get point direction relative to pivot
    //    dir = Quaternion.Euler(angles) * dir; // rotate it
    //    point = dir + pivot; // calculate rotated point
    //    return point; // return it
    //}

}
