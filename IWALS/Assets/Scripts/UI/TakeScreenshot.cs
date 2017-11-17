using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;

public class TakeScreenshot : MonoBehaviour {

    private int count;
    private int resWidth = 192;
    private int resHeight = 108;

    public Camera myCamera;
    //public Image[] thumbnails;

    public Image prefImage;
    public Image tempImg;
    public GameObject container;
    public List<Image> images;
    //public Dictionary<RectTransform, Image> tumbs;

    public GameObject gm;
    
    
	// Use this for initialization
	void Start () {

        myCamera.GetComponent<Camera>();
        myCamera.enabled = false;

        count = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) {
            takeScreenshot();            
        }
    }

    public void takeScreenshot() {

        myCamera.enabled = true;
        count++;
        //Application.CaptureScreenshot("Assets/Resources/Screenshots/Screenshot" + count + ".png");

        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        myCamera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        myCamera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, rt.width, rt.height), 0, 0);
        screenShot.Apply();
        myCamera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        //byte[] bytes = screenShot.EncodeToPNG();
        //string filename = "Assets/Resources/Screenshots/Screenshot" + count + ".png";
        //System.IO.File.WriteAllBytes(filename, bytes);
        //Debug.Log(string.Format("Took screenshot to: {0}", filename));

        myCamera.enabled = false;

        AddToMedia(screenShot);
    }

    public void AddToMedia(Texture2D screenshot) {
        
        // prefImage must be in the scene!!

        tempImg = Instantiate(prefImage, container.transform) as Image;
        tempImg.gameObject.name = "Thumbnail" + images.Count;
        images.Add(tempImg);

        // here we send/collect the file
        // gm.GetComponent<MediaHandler>().AddFileToArray(tempImg);

        //prefImage.gameObject.SetActive(false);

        Material mat = new Material(Shader.Find("UI/Default"));
        if (screenshot == null)
            Debug.Log("Loading Failed");
        else
            mat.mainTexture = screenshot;

        if (tempImg == null)
            Debug.Log("Prefab is null!");

        #region Resize legacy
        //tex.Resize(256, 256);
        //Sprite spr = Sprite.Create(tex, new Rect(0.0f, 0.0f, 100f, 100f), new Vector2(0, 0), 100.0f);

        //thumbnails[count-1].sprite = spr;

        //thumbnails[count - 1].material = mat;
        //thumbnails[count - 1].GetComponent<ThumbnailBehaviour>().SetActive(true);
        #endregion

        tempImg.material = mat;
        tempImg.GetComponent<ThumbnailBehaviour>().SetActive(true);

        prefImage = tempImg;

        // Content expansion
        if (images.Count > 4) {
            //Debug.Log("Expanding Rect!!");
            Rect tmpRect = container.GetComponent<RectTransform>().rect;
            container.GetComponent<RectTransform>().sizeDelta = new Vector2(tmpRect.width + 154, 0);
            //container.GetComponent<RectTransform>(). += new Vector3(110.25f, 0, 0);
        }

    }

}
