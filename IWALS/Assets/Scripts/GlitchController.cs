using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchController : MonoBehaviour {

    public int ID;

    public bool solved;
    public bool captured;

    public int distanceFar = 5;
    public int distanceShort = 2;

    public GameObject check;

    public GameObject cam;
    public GameObject myParticle;
    public GameObject video;
    public GameManager myGameManager;
    public MidiController myMidiController;
    public KeyboardController myKeyboardController;

    public enum State {
        Far,
        InRange,
        Interact,
    }
    public State state;

    // Use this for initialization
    void Start () {
        Debug.Log("Puzzle active");
        myGameManager.GetComponent<GameManager>();
        myMidiController.GetComponent<MidiController>();
        myKeyboardController.GetComponent<KeyboardController>();

        //StartCoroutine(checkDistance());

        NextState();
		
	}

    IEnumerator FarState() {
        Debug.Log("FarState");
        myParticle.SetActive(false);
        video.SetActive(false);
        myGameManager.setHighlightedSliders(3);
        while (state == State.Far) {

            if (checkDistance(5)) {
                state = State.InRange;
            }
            
            yield return new WaitForSeconds(.1f);
        }
        NextState();
    }

    IEnumerator InRangeState() {
        Debug.Log("InRangeState");
        myParticle.SetActive(true);
        video.SetActive(true);
        myGameManager.setHighlightedSliders(5);
        while (state == State.InRange) {

            if (!checkDistance(5)) {
                SwitchState(State.Far);
            }
            if (checkDistance(3)) {
                SwitchState(State.Interact);
            }
                        
            yield return new WaitForSeconds(.1f);
        }
    }
    
    IEnumerator InteractState() {
        Debug.Log("InteractState");
        myMidiController.glitchFader = myParticle.GetComponent<FadeController>();
        myKeyboardController.myGlitchFader = myParticle.GetComponent<FadeController>();
        while (state == State.Interact) {
            if (!checkDistance(3)) {
                SwitchState(State.InRange);
            }

            if (myParticle.GetComponent<FadeController>().alpha <= 0) {
                myGameManager.recordButtonHighlight.SetActive(true);
                solved = true;
            } else {
                myGameManager.recordButtonHighlight.SetActive(false);
                solved = false;
            }
            //if (solved) {
            //    Debug.Log("Solved! Capturing allowed");
            //    myGameManager.recordButtonHighlight.SetActive(true);
            //}
            if (captured) {
                check.SetActive(true);
                myParticle.SetActive(false);
                video.SetActive(false);
                myGameManager.recordButtonHighlight.SetActive(false);
                StopAllCoroutines();
            }
            yield return new WaitForSeconds(.1f);
        }
        myGameManager.recordButtonHighlight.SetActive(false);
    }

    // --> Crashes the game
    //IEnumerator checkDistance() {
    //    float distance = 0;
    //    while (true) {
    //        distance = Vector3.Distance(this.transform.position, cam.transform.position);
    //        Debug.Log("Distance: " + distance);
    //        if (distance < distanceFar) {
    //            state = State.Interact;
    //        } else if (distance < distanceShort) {
    //            state = State.InRange;
    //        }else {
    //            state = State.Far;
    //        }

    //        yield return new WaitForSeconds(.1f);
    //    }
    //}

    public bool checkDistance(int distance) {
        //Debug.Log("Distance: " + Vector3.Distance(this.transform.position, cam.transform.position));
        if (Vector3.Distance(this.transform.position, cam.transform.position) < distance) {
            return true;
        } else {
            return false;
        }
    }

    void NextState() {
        string methodName = state.ToString() + "State";
        System.Reflection.MethodInfo info =
            GetType().GetMethod(methodName,
                                System.Reflection.BindingFlags.NonPublic |
                                System.Reflection.BindingFlags.Instance);
        StartCoroutine((IEnumerator)info.Invoke(this, null));
    }
    void SwitchState(State state) {
        this.state = state;
        switch (state) {
            case State.Far:
                StartCoroutine(FarState());
                break;
            case State.InRange:
                StartCoroutine(InRangeState());
                break;
            case State.Interact:
                StartCoroutine(InteractState());
                break;
        }
    }
}
