//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.EventSystems;

//public class BoxBehaviour : MonoBehaviour, IPointerEnterHandler {

//    ThumbnailBehaviour myThumbnail;

//    int parentBox;

//    // Use this for initialization
//    void Start () {

//        parentBox = 0;
		
//	}
	
//	// Update is called once per frame
//	void Update () {
		
//	}

//    public void OnPointerEnter(PointerEventData eventData) {
//        if (this.gameObject.transform.parent.parent.name == "MediaBox")
//            parentBox = 1;
//        else if (this.gameObject.transform.parent.parent.name == "EditingBox")
//            parentBox = 2;
//        else
//            Debug.Log("Doesn't work this way");

//        //myThumbnail.changeParent(parentBox);
//        Debug.Log("Mouse over box: " + parentBox);
//    }
//}
