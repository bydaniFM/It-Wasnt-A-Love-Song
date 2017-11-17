using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;
using Kino;

public class MidiController : MonoBehaviour {

    //Attributes
    //public Slider[] sliders;

    //public Image[] slidersImages;
    //public float value_min;
    //public float value_max;
    //public float startingValue;
    //public float currentValue;
    //public GameObject object01;

    //public  GameObject               cubePrefab;
    //List    <KnobTestCube>           cubes;

    public  Camera                   mainCamera;
    public  CameraControl            cameraController;

    public  AnalogGlitch             analogGlitch;
    public  DigitalGlitch            digitalGlitch;

    public  GameObject               myLight;
    public  LightController          pointLightController;
    public  Light                    pointLight;
    public  FadeController           glitchFader;
    public  AudioController          audioController;
    public  TakeScreenshot           screenshotController;
    public  MovieTextureScript       movieTexture;

    public  MediaHandler             mediaHandler;
    public  GameObject               currentFile;
    

    // Use this for initialization
    void Start ()
    {
        //cubes = new List<KnobTestCube>();

        //cameraController =      mainCamera.GetComponent<CameraControl>();

        //analogGlitch =          mainCamera.GetComponent<AnalogGlitch>();
        //digitalGlitch =         mainCamera.GetComponent<DigitalGlitch>();
        pointLightController =  myLight.GetComponent<LightController>();
        pointLight =            myLight.GetComponent<Light>();
	}

    void Update()
    {
        var channels = MidiMaster.GetKnobNumbers();

        //if(cubes.Count != channels.Length)
        //{
        //    // Instantiate the new cube.
        //    var go = Instantiate<GameObject>(cubePrefab);
        //    go.transform.position = Vector3.right * (cubes.Count + 100);

        //    // Initialize the cube.
        //    var cube = go.GetComponent<KnobTestCube>();
        //    cube.knobNumber = channels[cubes.Count];

        //    // Add it to the cubes list.
        //    cubes.Add(cube);
        //}
    }

    void OnEnable()
    {
        MidiMaster.knobDelegate += Knob;
    }

    void OnDisable()
    {
        MidiMaster.knobDelegate -= Knob;
    }

    void Knob(MidiChannel channel, int knobNumber, float knobValue)
    {
        //Debug.Log("Knob: " + knobNumber + ", KnobValue" + knobValue);

        switch (knobNumber)
        {
            #region Horizontal Camera Movement
            case 0:
                cameraController.setHAngle(knobValue);
                //analogGlitch.scanLineJitter = knobValue;
                //Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Camera Zoom In/Out
            case 16:
                cameraController.setZoom(knobValue);
                //Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Vertical Camera Movement
            case 1:
                cameraController.setHeight(knobValue);
                //Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Camera angle / Tilt
            case 17:
                Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Horizontal Light Movement
            case 2:
                pointLightController.setHAngle(knobValue);
                //Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region  Intensity of myLight
            case 18:
                pointLight.intensity = knobValue * 2;
                //Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Colourful Glitch // Alpha channel
            case 3:
                //analogGlitch.colorDrift = knobValue;
                glitchFader.glitchFade(knobValue);
                Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region TV Distortion Glitch // Alpha channel
            case 19:
                
                Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Light-Rays Distortion // Alpha Channel
            case 4:
                //analogGlitch.scanLineJitter = knobValue;
                Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Pixelated Distortion // Alpha Channel
            case 20:
                glitchFader.glitchFade(knobValue);
                Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Sound manipulation
            case 5: //Volume Manipulation
                audioController.changeAudioVolume(knobValue);
                Debug.Log("Switch Case: " + knobNumber);
                break;

            case 6: //Pitch Manipulation
                audioController.changeAudioPitch(knobValue);
                Debug.Log("Switch Case: " + knobNumber);
                break;

            case 7: //Voice Manipulation
                
                Debug.Log("Switch Case: " + knobNumber);
                break;

            case 21: //Third sound variable   
                audioController.changeAudioSpread(knobValue);
                Debug.Log("Switch Case: " + knobNumber);
                break;

            case 22: //Forth sound variable
                audioController.changeAudioReverb(knobValue);
                Debug.Log("Switch Case: " + knobNumber);
                break;

            case 23: //Second Voice variable
                Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Media manipulating
            case 41:
                //Play preview
                if (knobValue == 1) {
                    if (movieTexture.playButton.activeInHierarchy) {
                        movieTexture.playPreview();
                    }
                }
                Debug.Log("Play Preview Switch Case: " + knobNumber);
                break;
            case 42:
                //Square Button: select file
                
                Debug.Log(" Select FileSwitch Case: " + knobNumber);
                break;
            case 43:
                //Left Arrow: move media file left on timeline
                if (knobValue == 1)
                    mediaHandler.ChangeFilePositionLeft();
                Debug.Log("Switch Case: " + knobNumber);
                break;
            case 44:
                //Right Arrow: move media file right on timeline
                if (knobValue == 1)
                    mediaHandler.ChangeFilePositionRight();
                Debug.Log("Switch Case: " + knobNumber);
                break;
            case 45:
                //Circle Button: collect media file  -->> NEW COLLECT SHADOW
                //screenshotController.takeScreenshot();
                if (knobValue == 1) {
                    //mediaHandler.AddFileToArray();
                    this.GetComponent<GameManager>().setCaptured(true);
                }
                Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Cycle button
            case 46:
                //Check state: changes between media folder and timeline
                if (knobValue == 1)
                    mediaHandler.CheckFolderStatus();
                Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Media Folder Track Arrows
            case 58:    //Left Arrow 
                if (knobValue == 1)
                    mediaHandler.leftTrackButton();
                Debug.Log("Switch Case: " + knobNumber);
                break;

            case 59:    //Right Arrow
                if (knobValue == 1)
                    mediaHandler.rightTrackButton();
                Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Set Button // Changes media type
            case 60:
                //Set Button: changes between media types
                if (knobValue == 1)
                    mediaHandler.switchBetweenMediaType();
                Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            #region Time Line Arrows
            case 61:    //Left Arrow Timeline
                if (knobValue == 1)
                    mediaHandler.leftTimeLineButton();
                Debug.Log("Switch Case: " + knobNumber);
                break;
            case 62:    //Right Arrow Timeline
                if (knobValue == 1)
                    mediaHandler.rightTimeLineButton();
                Debug.Log("Switch Case: " + knobNumber);
                break;
            #endregion

            default:
                break;
        }
    }

    void Awake()
    {

        //for (int i = 0; i < 8; i++)
        //{
        //    knobNumbersList[i] = i;
        //}
        //currentValue = startingValue;
        //sliders[0] = GetComponent<Slider>();
        //if (sliders[0] != null)
        //{
        //    Debug.LogError(sliders[0].name + " - Does not contain a slider component.");
        //}
    }

    /// <summary>
    /// Gets the value changed on the slider and operates
    /// with that value.
    /// Set up it in the isnpector as Dynamic Float.
    /// </summary>
    /// <param name="newValue"></param>
    //public void SliderPosX(float newValue)
    //{
    //    Debug.Log("The value has changed to " + newValue);
    //    //To do
    //    Vector3 pos = object01.transform.position;
    //    pos.x = newValue;
    //    object01.transform.position = pos;
    //}

    //public void SliderPosY(float newValue)
    //{
    //    Debug.Log("The value has changed to " + newValue);
    //    //To do
    //    Vector3 pos = object01.transform.position;
    //    pos.y = newValue;
    //    object01.transform.position = pos;
    //}

    //public void SliderRotZ(float newValue)
    //{
    //    Debug.Log("The value has changed to " + newValue);
    //    //To do
    //    Quaternion rot = object01.transform.rotation;
    //    rot.y = newValue;
    //    object01.transform.rotation = rot;
    //}
}
