using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movie : MediaFileClass {
    
    public MovieTexture movieTexture;
    public float duration;
    public GameObject highlight;

    public Movie(MovieTexture movieTexture, float duration) {
        this.movieTexture = movieTexture;
        this.duration = duration;
    }
    public Movie(Image img, GameObject go, string st, bool inMedia, MovieTexture movieTexture, float duration) : base(img, go, st, inMedia) {
        this.movieTexture = movieTexture;
        this.duration = duration;
    }

    public void sethighlight(bool opc) {
        highlight.SetActive(opc);
    }
}
