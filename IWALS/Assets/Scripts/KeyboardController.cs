using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour {

    public CameraControl myCamController;
    public Light myLight;
    private LightController myLightController;
    public FadeController myGlitchFader;

    [Range(0.0f, 0.01f)]
    public float camRotSpeed;
    [Range(0.0f, 0.01f)]
    public float camZoomSpeed;
    [Range(0.0f, 0.01f)]
    public float camHeightSpeed;
    [Range(0.0f, 0.01f)]
    public float lightRotSpeed;
    [Range(0.0f, 0.02f)]
    public float lightIntSpeed;
    [Range(0.0f, 0.01f)]
    public float glitchASpeed;

    public float axisVCam;
    public float axisAGlitch = 1;

    //public float slider1;

	// Use this for initialization
	void Start () {
        myLightController = myLight.GetComponent<LightController>();
	}
	
	// Update is called once per frame
	void Update () {

        #region Horizontal Camera Movement
        if (Input.GetKey(KeyCode.A)) {
            myCamController.setHAngle(myCamController.horizontalAngle + camRotSpeed);
        }
        if (Input.GetKey(KeyCode.Z)){
            myCamController.setHAngle(myCamController.horizontalAngle - camRotSpeed);
        }
        #endregion

        #region Camera Zoom In/Out
        if (Input.GetKey(KeyCode.Alpha1)) {
            myCamController.setZoom(myCamController.zoomFactor/myCamController.maxCloseZoom + camZoomSpeed);
        }
        if (Input.GetKey(KeyCode.Q)) {
            myCamController.setZoom(myCamController.zoomFactor/ myCamController.maxCloseZoom - camZoomSpeed);
        }
        #endregion

        #region Vertical Camera Movement
        if (Input.GetKey(KeyCode.S)) {
            axisVCam += camHeightSpeed;
            myCamController.setHeight(axisVCam);
        }
        if (Input.GetKey(KeyCode.X)) {
            axisVCam -= camHeightSpeed;
            myCamController.setHeight(axisVCam);
        }
        #endregion

        #region Light Movement
        if (Input.GetKey(KeyCode.D)) {
            myLightController.setHAngle(myLightController.horizontalAngle + lightRotSpeed);
        }
        if (Input.GetKey(KeyCode.C)) {
            myLightController.setHAngle(myLightController.horizontalAngle - lightRotSpeed);
        }
        #endregion

        #region  Light Intensity
        if (Input.GetKey(KeyCode.Alpha3)) {
            myLight.intensity += lightIntSpeed;
        }
        if (Input.GetKey(KeyCode.E)) {
            myLight.intensity -= lightIntSpeed;
        }
        #endregion

        #region Glitch Alpha
        if (Input.GetKey(KeyCode.F)) {
            axisAGlitch += glitchASpeed;
            myGlitchFader.glitchFade(axisAGlitch);

        }
        if (Input.GetKey(KeyCode.V)) {
            axisAGlitch -= glitchASpeed;
            myGlitchFader.glitchFade(axisAGlitch);
        }
        if(Input.GetKeyUp(KeyCode.F) || Input.GetKeyUp(KeyCode.V)) {
            axisAGlitch = 1;
            myGlitchFader.glitchFade(axisAGlitch);
        }
        #endregion
    }
}
