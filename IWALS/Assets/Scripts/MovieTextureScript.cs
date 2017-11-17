using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieTextureScript : MonoBehaviour {

    public GameObject playButton;

    public Material myMaterial;
    //public MovieTexture[] movies;
    public Movie[] myMovies;
    private float[] durations;

	// Use this for initialization
	void Start () {

        durations = new float[4];
        durations[0] = 7;
        durations[1] = 28;
        durations[2] = 18;
        durations[3] = 55;

        myMaterial = new Material(this.GetComponent<Renderer>().material);

        myMovies = new Movie[4];
        for (int i = 0; i < 4; i++) {
            myMovies[i] = new Movie((Resources.Load("movie" + (i + 1)) as MovieTexture), durations[i]);
        }

        //StartCoroutine(Play());

        //((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
        //((MovieTexture)GetComponent<Renderer>().material.mainTexture).loop = true;

    }

    public void playPreview() {
        StartCoroutine(Play());
    }

    IEnumerator Play() {
        playButton.SetActive(false);
        //setMovies();
        for (int i = 0; i < myMovies.Length; i++) {
            if (myMovies[i] != null) {
                myMaterial.mainTexture = myMovies[i].movieTexture;
                this.GetComponent<Renderer>().material = myMaterial;
                myMovies[i].movieTexture.Play();
                yield return new WaitForSeconds(myMovies[i].duration);
                myMovies[i].movieTexture.Stop();
            }
        }
        playButton.SetActive(true);
    }

    public void setMovies(GameObject[] moviesTimeline) {
        //myMovies = movies;
        myMovies = new Movie[4];
        for (int i = 0; i < 4; i++) {
            if(moviesTimeline[i] != null)
                myMovies[i] = moviesTimeline[i].GetComponent<Movie>();
        }
    }
}

//public class Movie {

//    public MovieTexture movieTexture;
//    public float duration;

//    public Movie(MovieTexture movieTexture, float duration) {
//        this.movieTexture = movieTexture;
//        this.duration = duration;
//    }
//}