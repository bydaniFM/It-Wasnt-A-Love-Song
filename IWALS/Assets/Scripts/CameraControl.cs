using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Cameras;

public class CameraControl : MonoBehaviour {

    //public Camera camera;
    public GameObject mainCamera;
    public GameObject pivot;
    private GameObject initTransform;
    private GameObject tempTransform;

    public float maxCloseZoom;
    public float maxFarZoom;

    public float maxHeight;
    public float minHeight;
    public float height;

    public float horizontalAngle;
    public float zoomFactor;

	// Use this for initialization
	void Start () {

        initTransform = new GameObject("CamInitTransform");
        initTransform.transform.position = new Vector3(0, 4, maxFarZoom);
        tempTransform = new GameObject("CamTempTransform");
        tempTransform.transform.position = initTransform.transform.position;

        maxHeight = maxHeight * 2;

    }

    public void setHAngle(float value) {
        horizontalAngle = value;

        tempTransform.transform.position = initTransform.transform.position;
        tempTransform.transform.rotation = initTransform.transform.rotation;

        tempTransform.transform.RotateAround(pivot.transform.position, Vector3.up, horizontalAngle * 360);

        this.transform.position = tempTransform.transform.position;
        this.transform.rotation = tempTransform.transform.rotation;
    }

    public void setZoom(float value) {
        //if (mainCamera.transform.localPosition.z + value/maxCloseZoom > maxFarZoom && mainCamera.transform.localPosition.z + value/maxCloseZoom < maxCloseZoom) {
            zoomFactor = value * maxCloseZoom;
            mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, mainCamera.transform.localPosition.y, zoomFactor);//mainCamera.transform.localPosition.z + 
        //}
    }

    public void setHeight(float value) {
        height = value * maxHeight - maxHeight / 2;
        mainCamera.transform.localPosition = new Vector3(mainCamera.transform.localPosition.x, height, mainCamera.transform.localPosition.z);
    }

    //public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles) {
    //    Vector3 dir = point - pivot; // get point direction relative to pivot
    //    dir = Quaternion.Euler(angles) * dir; // rotate it
    //    point = dir + pivot; // calculate rotated point
    //    return point; // return it
    //}

}

// Update Legacy
//
//void Update() {
//    /*
//    if (Input.GetMouseButtonDown(0) && camera.pixelRect.Contains(Input.mousePosition)) { // if left button pressed...
//        cam.GetComponent<FreeLookCam>().enabled = true;
//        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
//        RaycastHit hit;
//        if (Physics.Raycast(ray, out hit)) {
//            // the object identified by hit.transform was clicked
//            if(hit.transform.gameObject.tag == "Clickable") {
//                Debug.Log("Changing camera target");
//                cam.GetComponent<FreeLookCam>().SetTarget(hit.transform);
//            }
//        }
//    }
//    if (Input.GetMouseButtonUp(0)) {
//        cam.GetComponent<FreeLookCam>().enabled = false;
//    }

//    if(Input.GetAxis("Mouse ScrollWheel") != 0f) {
//        cam.GetComponent<ProtectCameraFromWallClip>().closestDistance -= Input.GetAxis("Mouse ScrollWheel") * zoomFactor;
//    }
//    */

//    /* ESTO FUNCIONA!
//    tempTransform.transform.position = initTransform.transform.position;
//    tempTransform.transform.rotation = initTransform.transform.rotation;

//    tempTransform.transform.RotateAround(pivot.transform.position, Vector3.up, horizontalAngle*360);

//    this.transform.position = tempTransform.transform.position;
//    this.transform.rotation = tempTransform.transform.rotation;
//    */

//    //tempPos = initPos;
//    //tempRot = initRot;

//    ////tempPos.RotateAround(pivot.transform.position, Vector3.up, horizontalAngle);

//    //Vector3 rotation = Quaternion.Euler(0, horizontalAngle, 0) * Vector3.forward;
//    //tempPos = RotatePointAroundPivot(pivot.transform.position, Vector3.up, rotation);
//    //this.transform.position = tempPos;
//    //this.transform.rotation = tempRot;

//}