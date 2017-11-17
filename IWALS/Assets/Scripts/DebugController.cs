using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugController : MonoBehaviour {

    public Text debugText;
    public GameObject myCamera;
    public GameObject myLight;

	// Use this for initialization
	void Start () {

        debugText.GetComponent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (debugText.gameObject.activeInHierarchy)
                debugText.gameObject.SetActive(false);
            else
                debugText.gameObject.SetActive(true);
        }

        debugText.text = "Camera angle: " + myCamera.GetComponent<CameraControl>().horizontalAngle +
            "\nLight angle: " + myLight.GetComponent<LightController>().horizontalAngle;


    }
}
