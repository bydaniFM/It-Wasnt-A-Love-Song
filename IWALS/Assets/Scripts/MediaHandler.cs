using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaHandler : MonoBehaviour {

    public GameObject currentFile;
    public GameObject[] allFilles;
    public int fileNumber;

    public MovieTextureScript myMovieTextureScript;
    public MidiController midiController;

    //left side of the UI
    public GameObject[] movieFiles;
    public GameObject[] audioFiles;
    public GameObject[] voiceFiles;

    //timeline: right side of the UI
    public GameObject[] movieFilesTimeline;
    public GameObject[] audioFilesTimeline;
    public GameObject[] voiceFilesTimeline;

    //Timeline transform positions
    public Transform videoTransform0;
    public Transform videoTransform1;
    public Transform videoTransform2;
    public Transform videoTransform3;

    /// <summary>
    /// struct which works as a pointer
    /// it has the value for the row (media type)
    /// also has the value for the position on his row 
    /// </summary>
    [System.Serializable]
    public struct filePosition
    {
        public int x;//column
        public int y;//row
    }
    //pointer values for 
    public filePosition filePos;
    public filePosition filePosTimeLine;

    void Start()
    {
        movieFilesTimeline = new GameObject[4];
        currentFile = allFilles[0];
    }

    void Update()
    {
        //this.checkCurrentFile();
        //currentFile.highlight();
    }

    public void SearchForFile(int fileId)
    {
        switch(fileId)
        {
            case 0:
                movieFiles[0] = allFilles[0];
                movieFiles[0].GetComponent<Movie>().inMediaFolder = true;
                movieFiles[0].GetComponent<Image>().enabled = true;

                break;

            case 1:
                movieFiles[1] = allFilles[1];
                movieFiles[1].GetComponent<MediaFileClass>().inMediaFolder = true;
                movieFiles[1].GetComponent<Image>().enabled = true;
                break;

            case 2:
                movieFiles[2] = allFilles[2];
                movieFiles[2].GetComponent<MediaFileClass>().inMediaFolder = true;
                movieFiles[2].GetComponent<Image>().enabled = true;
                break;

            case 3:
                movieFiles[3] = allFilles[3];
                movieFiles[3].GetComponent<MediaFileClass>().inMediaFolder = true;
                movieFiles[3].GetComponent<Image>().enabled = true;
                break;

            case 4:
                audioFiles[0] = allFilles[4];
                break;

            case 5:
                audioFiles[1] = allFilles[5];
                break;

            case 6:
                audioFiles[2] = allFilles[6];
                break;

            case 7:
                voiceFiles[0] = allFilles[7];
                break;

            case 8:
                voiceFiles[1] = allFilles[8];
                break;

            case 9:
                voiceFiles[2] = allFilles[9];
                break;
        }
    }

    /// <summary>
    /// Checks the current file we should be manipulating
    /// </summary>
    /// <param name="position"></param>
    public void checkCurrentFileMediaFolder()
    {
        currentFile.GetComponent<Movie>().sethighlight(false);
        switch (filePos.y)
        {
            case 0:
                //movieFiles[position.x].highlight();
                currentFile = movieFiles[filePos.x];
                currentFile.GetComponent<Movie>().sethighlight(true);
                Debug.Log("Current file" + currentFile.name);
                break;

            case 1:
                //audioFiles[position.x].highlight();
                currentFile = audioFiles[filePos.x];
                Debug.Log("Current file" + currentFile.name);
                break;

            case 2:
                //voiceFiles[position.x].highlight();
                currentFile = voiceFiles[filePos.x];
                Debug.Log("Current file" + currentFile.name);
                break;
        }
    }

    public void checkCurrentFileTimeLine()
    {
        switch (filePosTimeLine.y)
        {
            case 0:
                //movieFiles[position.x].highlight();
                currentFile = movieFilesTimeline[filePosTimeLine.x];
                //Debug.Log("Current file" + currentFile.name);
                break;

            case 1:
                //audioFiles[position.x].highlight();
                currentFile = audioFilesTimeline[filePosTimeLine.x];
                //Debug.Log("Current file" + currentFile.name);
                break;

            case 2:
                //voiceFiles[position.x].highlight();
                currentFile = voiceFilesTimeline[filePosTimeLine.x];
                //Debug.Log("Current file" + currentFile.name);
                break;
        }
    }

    public void AddFile()
    {
        bool fileCollected = false;
        Debug.Log("Moving file" + this.allFilles[0]);
        switch (allFilles[fileNumber].GetComponent<MediaFileClass>().stringType)
        {
            case "Movie":
                for (int i = 0; i < movieFiles.GetLength(0) && fileCollected != true; i++)
                {
                    Debug.Log("Movie file");
                    if (movieFiles[i] == null)
                    {
                        this.movieFiles[i] = this.allFilles[fileNumber];
                        this.movieFiles[i].GetComponent<MediaFileClass>().inMediaFolder = true;
                        fileCollected = true;
                        fileNumber++;
                    }
                }
                break;

            case "Audio":
                for (int i = 0; i < audioFiles.GetLength(0) && fileCollected != true; i++)
                {
                    Debug.Log("Audio file");
                    if (audioFiles[i] == null)
                    {
                        this.audioFiles[i] = this.allFilles[fileNumber];
                        this.audioFiles[i].GetComponent<MediaFileClass>().inMediaFolder = true;
                        fileCollected = true;
                        fileNumber++;
                    }
                }
                break;

            case "Voice":
                for (int i = 0; i < audioFiles.GetLength(0) && fileCollected != true; i++)
                {
                    Debug.Log("Voice file");
                    if (voiceFiles[i] == null)
                    {
                        this.voiceFiles[i] = this.allFilles[fileNumber];
                        this.voiceFiles[i].GetComponent<MediaFileClass>().inMediaFolder = true;
                        fileCollected = true;
                        fileNumber++;
                    }

                }
                break;
        }
    }


    /// <summary>
    /// When the player press collect media file, this function
    /// Adds a media file to the UI/media folder array
    /// depending on the mediafyle type: movie, audio or voice
    /// </summary>
    /// <param name="mediaFile"></param>
    public void AddFileToArray()
    {
        bool fileCollected = false;
        Debug.Log("Moving file"+ currentFile);
        switch(currentFile.GetComponent<MediaFileClass>().stringType)
        {
            case "Movie":
                for (int i = 0; i < movieFilesTimeline.GetLength(0) && fileCollected != true ; i++)
                {
                    Debug.Log("Movie file");
                    if(movieFilesTimeline[i] == null)
                    {
                        this.movieFilesTimeline[i] = this.movieFiles[fileNumber];
                        this.movieFilesTimeline[i].GetComponent<MediaFileClass>().inMediaFolder = true;
                        fileCollected = true;
                        fileNumber++;
                    }  
                }
                break;

            case "Audio":
                for (int i = 0; i < audioFilesTimeline.GetLength(0) && fileCollected != true; i++)
                {
                    Debug.Log("Audio file");
                    if (audioFilesTimeline[i] == null)
                    {
                        this.audioFilesTimeline[i] = this.audioFiles[fileNumber];
                        this.audioFilesTimeline[i].GetComponent<MediaFileClass>().inMediaFolder = true;
                        fileCollected = true;
                        fileNumber++;
                    }
                }
                break;

            case "Voice":
                for (int i = 0; i < voiceFilesTimeline.GetLength(0) && fileCollected != true; i++)
                {
                    Debug.Log("Voice file");
                    if (voiceFilesTimeline[i] == null)
                    {
                        this.voiceFilesTimeline[i] = this.voiceFiles[fileNumber];
                        this.voiceFilesTimeline[i].GetComponent<MediaFileClass>().inMediaFolder = true;
                        fileCollected = true;
                        fileNumber++;
                    }

                }
                break;
        }
    }

    /// <summary>
    /// Adds the media file to the time line array
    /// when press cycle and the media file is on the
    /// normal folder
    /// </summary>
    /// <param name="mediaFile"></param>
    public void AddFileToTimeLineArray()
    {
        bool fileMoved = false;
        Debug.Log("Moving file" + this.movieFiles[filePos.x]);
        switch (currentFile.GetComponent<MediaFileClass>().stringType)
        {
            case "Movie":
                for (int i = 0; i < movieFiles.GetLength(0) && fileMoved != true; i++)
                {
                    if (movieFilesTimeline[i] == null)
                    {
                        if(i == 0) {
                            currentFile.transform.position = videoTransform0.transform.position;
                        }else if(i == 1) {
                            currentFile.transform.position = videoTransform1.transform.position;
                        } else if (i == 2) {
                            currentFile.transform.position = videoTransform2.transform.position;
                        } else if (i == 3) {
                            currentFile.transform.position = videoTransform3.transform.position;
                        }
                        movieFilesTimeline[i] = this.movieFiles[filePos.x];
                        movieFiles[filePos.x] = null;
                        this.movieFilesTimeline[i].GetComponent<MediaFileClass>().inMediaFolder = false;
                        fileMoved = true;
                    }
                }
                myMovieTextureScript.setMovies(movieFilesTimeline);
                break;

            case "Audio":
                for (int i = 0; i < audioFiles.GetLength(0) && fileMoved != true; i++)
                {
                    if (audioFilesTimeline[i] == null)
                    {
                        audioFilesTimeline[i] = this.audioFiles[filePos.x];
                        audioFiles[filePos.x] = null;
                        this.audioFilesTimeline[i].GetComponent<MediaFileClass>().inMediaFolder = false;
                        fileMoved = true;
                    }
                }
                break;

            case "Voice":
                for (int i = 0; i < voiceFiles.GetLength(0) && fileMoved != true; i++)
                {
                    if (voiceFilesTimeline[i] == null)
                    {
                        voiceFilesTimeline[i] = this.voiceFiles[filePos.x];
                        voiceFiles[filePos.x] = null;
                        this.voiceFilesTimeline[i].GetComponent<MediaFileClass>().inMediaFolder = false;
                        fileMoved = true;
                    }
                }
                break;
        }
    }

    /// <summary>
    /// check if the media file is in the media folder or
    /// in the time line. Depending on the state, 
    /// uses one function or another
    /// </summary>
    /// <param name="mediaFile"></param>
    public void CheckFolderStatus()
    {
        if (currentFile.GetComponent<MediaFileClass>().inMediaFolder == true)   //if is in the media folder
        {   
            AddFileToTimeLineArray();  //to timeline array
            return;
        }
        if (currentFile.GetComponent<MediaFileClass>().inMediaFolder == false)  //if is on timeline array
        {
            AddFileToArray();          //to normal media folder
            return;
        }
    }

    public void ChangeFilePositionRight()
    {
        bool fileMoved = false;
        GameObject auxFile;
        auxFile = currentFile;
        int filepositionaux = filePos.x;

        //depending on the media type
        //takes the next element in an aux variable
        switch (currentFile.GetComponent<MediaFileClass>().stringType)
        {
            case "Movie":
                for (int i = 0; i < movieFiles.GetLength(0) && fileMoved!= true; i++)
                {
                    if (i == filePos.x)
                    {
                        movieFiles[i] = movieFiles[i + 1];
                        movieFiles[i + 1] = auxFile;
                        fileMoved = true;
                    }
                }
                
                break;

            case "Audio":
                for (int i = 0; i < audioFiles.GetLength(0) && fileMoved != true; i++)
                {
                    if (i == filePos.x)
                    {
                        audioFiles[i] = audioFiles[i + 1];
                        audioFiles[i + 1] = auxFile;
                        fileMoved = true;
                    }
                }
                break;

            case "Voice":
                for (int i = 0; i < voiceFiles.GetLength(0) && fileMoved != true; i++)
                {
                    if (i == filePos.x)
                    {
                        voiceFiles[i] = voiceFiles[i + 1];
                        voiceFiles[i + 1] = auxFile;
                        fileMoved = true;
                    }
                }
                break;
        }
    }

    public void ChangeFilePositionLeft()
    {
        bool fileMoved = false;
        GameObject auxFile;
        auxFile = currentFile;
        int filepositionaux = filePos.x;

        //depending on the media type
        //takes the next element in an aux variable
        switch (currentFile.GetComponent<MediaFileClass>().stringType)
        {
            case "Movie":
                for (int i = 0; i < movieFiles.GetLength(0) && fileMoved != false; i++)
                {
                    if (i == filePos.x)
                    {
                        movieFiles[i] = movieFiles[i - 1];
                        movieFiles[i - 1] = auxFile;
                        fileMoved = true;
                    }
                }
                break;

            case "Audio":
                for (int i = 0; i < audioFiles.GetLength(0) && fileMoved != false; i++)
                {
                    if (i == filePos.x)
                    {
                        audioFiles[i] = audioFiles[i - 1];
                        audioFiles[i - 1] = auxFile;
                        fileMoved = true;
                    }
                }
                break;

            case "Voice":
                for (int i = 0; i < voiceFiles.GetLength(0) && fileMoved != false; i++)
                {
                    if (i == filePos.x)
                    {
                        voiceFiles[i] = voiceFiles[i - 1];
                        voiceFiles[i - 1] = auxFile;
                        fileMoved = true;
                    }
                }
                break;
        }
    }


    /// <summary>
    /// When press cycle, moves the media file back to the media folder
    /// </summary>
    /// <param name="mediaFile"></param>
    public void AddFileBackToFolder()
    {
        switch (currentFile.GetComponent<MediaFileClass>().stringType)
        {
            case "Movie":
                for (int i = 0; i < movieFiles.GetLength(0); i++)
                {
                    if (movieFiles[i] != null)
                    {
                        movieFiles[i] = this.movieFilesTimeline[filePos.x];
                        movieFilesTimeline[filePos.x] = null;
                    }
                }
                break;

            case "Audio":
                for (int i = 0; i < audioFiles.GetLength(0); i++)
                {
                    if (audioFiles[i] != null)
                    {
                        audioFiles[i] = this.audioFilesTimeline[filePos.x];
                        audioFilesTimeline[filePos.x] = null;
                    }
                        
                }
                break;

            case "Voice":
                for (int i = 0; i < voiceFiles.GetLength(0); i++)
                {
                    if (voiceFiles[i] != null)
                    {
                        voiceFiles[i] = this.voiceFilesTimeline[filePos.x];
                        voiceFilesTimeline[filePos.x] = null;
                    }
                        
                }
                break;
        }
    }


    /// <summary>
    /// Function for the SET button
    /// </summary>
    public void switchBetweenMediaType ()
    {
        filePos.x = 0;
        filePos.y += 1;
        if (filePos.y == 3)
            filePos.y = 0;

        filePosTimeLine.x = 0;
        filePosTimeLine.y += 1;
        if (filePosTimeLine.y == 3)
            filePosTimeLine.y = 0;

        checkCurrentFileMediaFolder();
    }

    /// <summary>
    /// Function for the arrows
    /// </summary>
    /// <param name="array"></param>
    public void rightTrackButton ()
    {
        switch (filePos.y)
        {
            case 0:
                //movieFiles[position.x].highlight();
                if (filePos.x < movieFiles.GetLength(0))
                {
                    filePos.x +=1;
                    checkCurrentFileMediaFolder();
                }
                    
                break;

            case 1:
                //audioFiles[position.x].highlight();
                if (filePos.x < audioFiles.GetLength(0))
                {
                    filePos.x +=1;
                    checkCurrentFileMediaFolder();
                }
                    
                break;

            case 2:
                //voiceFiles[position.x].highlight();
                if (filePos.x < voiceFiles.GetLength(0))
                {
                    filePos.x += 1;
                    checkCurrentFileMediaFolder();
                }
                    
                break;
        }
        Debug.Log("keloke");
    }

    /// <summary>
    /// Function for the arrows
    /// </summary>
    /// <param name="array"></param>
    public void leftTrackButton()
    {
        switch (filePos.y)
        {
            case 0:
                //movieFiles[position.x].highlight();
                if (filePos.x > 0)
                {
                    filePos.x -=1;
                    checkCurrentFileMediaFolder();
                }
                    
                break;

            case 1:
                //audioFiles[position.x].highlight();
                if (filePos.x > 0)
                {
                    filePos.x -= 1;
                    checkCurrentFileMediaFolder();
                }
                    
                break;

            case 2:
                //voiceFiles[position.x].highlight();
                if (filePos.x > 0)
                {
                    filePos.x -= 1;
                    checkCurrentFileMediaFolder();
                }
                    
                break;
        }
    }

    /// <summary>
    /// Function for the arrows
    /// </summary>
    /// <param name="array"></param>
    public void rightTimeLineButton()
    {
        switch (filePosTimeLine.y)
        {
            case 0:
                //movieFiles[position.x].highlight();
                if(filePosTimeLine.x < movieFilesTimeline.GetLength(0))
                {
                    filePosTimeLine.x += 1;
                    checkCurrentFileTimeLine();
                }  
                break;

            case 1:
                //audioFiles[position.x].highlight();
                if (filePosTimeLine.x < audioFilesTimeline.GetLength(0))
                {
                    filePosTimeLine.x += 1;
                    checkCurrentFileTimeLine();
                }
                    
                    
                break;

            case 2:
                //voiceFiles[position.x].highlight();
                if (filePosTimeLine.x < voiceFilesTimeline.GetLength(0))
                {
                    filePosTimeLine.x += 1;
                    checkCurrentFileTimeLine();
                }   
                break;
        }
    }

    /// <summary>
    /// Function for the arrows
    /// </summary>
    /// <param name="array"></param>
    public void leftTimeLineButton()
    {
        switch (filePosTimeLine.y)
        {
            case 0:
                //movieFiles[position.x].highlight();
                if (filePosTimeLine.x > 0)
                {
                    filePosTimeLine.x -= 1;
                    checkCurrentFileTimeLine();
                }       
                break;

            case 1:
                //audioFiles[position.x].highlight();
                if (filePosTimeLine.x > 0)
                {
                    filePosTimeLine.x -= 1;
                    checkCurrentFileTimeLine();
                }    
                break;

            case 2:
                //voiceFiles[position.x].highlight();
                if (filePosTimeLine.x > 0)
                {
                    filePosTimeLine.x -= 1;
                    checkCurrentFileTimeLine();
                }                  
                break;
        }
    }
}
