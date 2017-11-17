using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ThumbnailBehaviour : MonoBehaviour, IDragHandler, IEndDragHandler {

    //public Camera camera;

    public GameObject mediaBox;
    public GameObject editingBox;

    public bool active;
    public bool highlighted;

	// Use this for initialization
	void Start () {

        //camera.GetComponent<Camera>();

        active = true;
        highlighted = true;
		
	}
	
	// Update is called once per frame
	void Update () {

        /*if (Input.GetMouseButton(0)) {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                // the object identified by hit.transform was clicked
                if (hit.transform.gameObject == this.gameObject) {
                    Debug.Log("Media grabbed");
                    if (highlighted) {
                        this.transform.position = Input.mousePosition;
                    }
                }
            }
        }*/
        
    }

    public void OnDrag(PointerEventData eventData) {
        //Debug.Log("Media grabbed");
        if (active) {
            this.transform.position = Input.mousePosition;
            SetHighlighted(false);
        }
        /*
        if (!this.GetComponent<RectTransform>().rect.Overlaps(editingBox.GetComponent<RectTransform>().rect)) {
            Debug.Log("Check out");
            if (this.GetComponent<RectTransform>().rect.Overlaps(mediaBox.GetComponent<RectTransform>().rect)) {
                Debug.Log("Check in");
                this.transform.SetParent(editingBox.transform);
            }
        }*/
        Rect editingRect = editingBox.transform.parent.parent.gameObject.GetComponent<RectTransform>().rect;
        //Rect editingRect = editingBox.GetComponent<RectTransform>().rect;
        Rect mediaRect = mediaBox.transform.parent.parent.gameObject.GetComponent<RectTransform>().rect;
        //Rect mediaRect = mediaBox.GetComponent<RectTransform>().rect;
        /*if (editingRect.Contains(Input.mousePosition)) {
            Debug.Log("In Editing");
            this.transform.SetParent(editingBox.transform);
        }
        if (mediaRect.Contains(Input.mousePosition)) {
            Debug.Log("In Media");
            this.transform.SetParent(mediaBox.transform);
        }*/

        if (Input.mousePosition.y < 326) {
            //Debug.Log("In Editing");
            this.transform.SetParent(editingBox.transform);
        }else if (Input.mousePosition.x > 1344) {
            //Debug.Log("In Media");
            this.transform.SetParent(mediaBox.transform);
        }else {
            this.transform.SetParent(mediaBox.transform.parent.parent.parent);
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        mediaBox.SetActive(false);
        mediaBox.SetActive(true);
    }

    public void SetActive(bool active) {
        this.active = active;
        SetHighlighted(true);
    }

    public void SetHighlighted(bool highlighted) {
        this.highlighted = highlighted;
        //Set the actual highlight...
        this.GetComponent<Outline>().enabled = highlighted;
    }
}
