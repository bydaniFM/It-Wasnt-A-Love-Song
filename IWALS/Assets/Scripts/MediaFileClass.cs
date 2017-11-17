using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MediaFileClass:MonoBehaviour
{

    public Image fileImage;
    public GameObject mediaContent;
    public string stringType;
    public bool inMediaFolder; //false= normal folder - true= timeline folder

    public MediaFileClass() {

    }
    public MediaFileClass (Image img, GameObject go, string st, bool inMediaF)
    {
        this.fileImage = img;
        this.mediaContent = go;
        this.stringType = st;
        this.inMediaFolder = inMediaF;
    }

}
