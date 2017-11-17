using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class KnobTestCube : MonoBehaviour {

    public int knobNumber;

    void Awake()
    {
        transform.position = Vector3.zero;
    }

    void Update()
    {
        var scaleY = MidiMaster.GetKnob(knobNumber);
        transform.localScale = new Vector3(1, scaleY, 1);
    }
}
