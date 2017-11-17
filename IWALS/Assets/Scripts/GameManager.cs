using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public enum State {
        Mission1,
        Mission2,
        Mission3,
    }
    public State state;

    public bool captured;

    public MediaHandler myMediaHandler;

    public GameObject lockedUI;
    public GameObject[] sliderHints;
    public GameObject[] checks;
    public GameObject recordButtonHighlight;
    public GameObject lockedAudio;
    public GameObject lockedVoice;
    public GameObject container2_1;
    public GameObject container2_2;

    public GameObject glitches;

    //public GameObject[] videos;
    //public GameObject[] sounds;
    //public GameObject[] voices;

    public GameObject myCamera;
    public GameObject myLight;

	// Use this for initialization
	void Start () {

        //foreach(Transform child in glitches.transform) {
        //    child.gameObject.SetActive(false);
        //}

        //sliderHints = new GameObject[8];
        myMediaHandler = this.GetComponent<MediaHandler>();
        recordButtonHighlight.SetActive(false);

        NextState();
	}

    // Collect the shadows
    IEnumerator Mission1State() {
        Debug.Log("Mission1: Enter");
        lockedUI.SetActive(true);
        setHighlightedSliders(3);

        bool shadowFound1 = false;
        bool shadowFound2 = false;
        bool shadowFound3 = false;
        bool shadowFound4 = false;
        int shadowFound = 0;

        while (state == State.Mission1) {

            shadowFound = checkShadows();
            if(shadowFound != 0) {
                // Checking if captured pressed
                while (shadowFound != 0 && !captured) {
                    if((shadowFound == 1 && !shadowFound1) || (shadowFound == 2 && !shadowFound2) || (shadowFound == 3 && !shadowFound3) || (shadowFound == 4 && !shadowFound4))
                        recordButtonHighlight.SetActive(true);
                    shadowFound = checkShadows();
                    yield return 0;
                }
                recordButtonHighlight.SetActive(false);
                if (captured) {
                    switch (shadowFound) {
                        case 1:
                            if (!shadowFound1) {
                                shadowFound1 = true;
                                checks[0].SetActive(true);
                                Debug.Log("Shadow " + shadowFound + " captured!");
                            }
                            break;
                        case 2:
                            if (!shadowFound2) {
                                shadowFound2 = true;
                                checks[1].SetActive(true);
                                Debug.Log("Shadow " + shadowFound + " captured!");
                            }
                            break;
                        case 3:
                            if (!shadowFound3) {
                                shadowFound3 = true;
                                checks[2].SetActive(true);
                                Debug.Log("Shadow " + shadowFound + " captured!");
                            }
                            break;
                        case 4:
                            if (!shadowFound4) {
                                shadowFound4 = true;
                                checks[3].SetActive(true);
                                Debug.Log("Shadow " + shadowFound + " captured!");
                            }
                            break;
                    }
                    captured = false;
                    recordButtonHighlight.SetActive(false);
                }
            }
            if (shadowFound1 && shadowFound2 && shadowFound3 && shadowFound4)
                state = State.Mission2;
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Mission1: Exit");
        NextState();
    }

    // Collect the glitches
    IEnumerator Mission2State() {
        Debug.Log("Mission2: Enter");
        lockedUI.SetActive(false);
        container2_1.SetActive(false);
        container2_2.SetActive(true);
        foreach (Transform child in glitches.transform) {
            child.gameObject.SetActive(true);
        }

        int countSolved = 0;
        while (state == State.Mission2) {
            foreach (Transform child in glitches.transform) {
                if (child.gameObject.GetComponent<GlitchController>().solved) {
                    if (captured) {
                        child.gameObject.GetComponent<GlitchController>().captured = true;
                        myMediaHandler.SearchForFile(child.gameObject.GetComponent<GlitchController>().ID);
                        countSolved++;
                        //captured = false;
                    }
                }
            }
            captured = false;
            if (countSolved >= 9)
                state = State.Mission3;
            else
                countSolved = 0;
            yield return new WaitForSeconds(.1f);
        }
        Debug.Log("Mission2: Exit");
        NextState();
    }

    IEnumerator Mission3State() {
        Debug.Log("Mission3: Enter");
        while (state == State.Mission3) {
            yield return 0;
        }
        Debug.Log("Mission3: Exit");
    }

    void NextState() {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info =
            GetType().GetMethod(methodName,
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));

        //switch (state) {
        //    case State.Mission1:
        //        break;
        //}
    }

    // Check the shadows for the first puzzle
    public int checkShadows() {

        float camPos = myCamera.GetComponent<CameraControl>().horizontalAngle;

        // MAN - 1
        float camMaxPos1 = 0.99f;
        float camMinPos1 = 0.63f;
        // MAN - 2
        float camMaxPos12 = 0.32f;
        float camMinPos12 = 0.15f;
        //WOMAN
        float camMaxPos2 = 0.71f;
        float camMinPos2 = 0.38f;
        //PHONE
        float camMaxPos3 = 0.27f;
        float camMinPos3 = 0f;
        //HANDS
        float camMaxPos4 = 1;
        float camMinPos4 = 0.83f;

        float lightPos = myLight.GetComponent<LightController>().horizontalAngle;

        // MAN - 1
        float lightMaxPos1 = 0.82f;
        float lightMinPos1 = 0.80f;
        // MAN - 2
        float lightMaxPos12 = 0.32f;
        float lightMinPos12 = 0.28f;
        //WOMAN
        float lightMaxPos2 = 0.65f;
        float lightMinPos2 = 0.63f;
        //PHONE
        float lightMaxPos3 = 0.24f;
        float lightMinPos3 = 0.18f;
        //HANDS
        float lightMaxPos4 = 0.11f;
        float lightMinPos4 = 0.05f;

        int solvedShadow = 0;

        //recordButtonHighlight.SetActive(true);

        if (camPos < camMaxPos1 && camPos > camMinPos1) {
            if(lightPos < lightMaxPos1 && lightPos > lightMinPos1) {
                solvedShadow = 1;
            }
        } else if (camPos < camMaxPos12 && camPos > camMinPos12) {
            if (lightPos < lightMaxPos12 && lightPos > lightMinPos12) {
                solvedShadow = 1;
            }
        }
        if (camPos < camMaxPos2 && camPos > camMinPos2) {
            if (lightPos < lightMaxPos2 && lightPos > lightMinPos2) {
                solvedShadow = 2;
            }
        }
        if (camPos < camMaxPos3 && camPos > camMinPos3) {
            if (lightPos < lightMaxPos3 && lightPos > lightMinPos3) {
                solvedShadow = 3;
            }
        }
        if (camPos < camMaxPos4 && camPos > camMinPos4) {
            if (lightPos < lightMaxPos4 && lightPos > lightMinPos4) {
                solvedShadow = 4;
            }
        }

        //if (solvedShadow == 0) {
        //    recordButtonHighlight.SetActive(false);
        //}
        Debug.Log("Checkshadows: " + solvedShadow);

        return solvedShadow;
    }

    public void setCaptured(bool opc) {
        if (recordButtonHighlight.activeInHierarchy) {
            captured = opc;
            recordButtonHighlight.SetActive(!opc);
        }
    }

    public void setHighlightedSliders(int num) {
        for(int i = 0; i < 8; i++) {
            if (i < num)
                sliderHints[i].SetActive(true);
            else
                sliderHints[i].SetActive(false);
        }
    }
}
