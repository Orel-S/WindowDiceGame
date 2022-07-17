using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraController : MonoBehaviour
{

    public Camera[] cameras;
    private int currentCameraIndex;
    public GameObject die, progressBar, duckMinigame, peaMinigame, scriptHolder, eventSystem;
    public int dieResult;
    private bool isPlayingMinigame = false;
    private int currMiniIndex = -1;

    // Start is called before the first frame update
    void Start()
    {

        die = GameObject.Find("Land");
        progressBar = GameObject.Find("ProgressBar");
        //These two should be adjusted
        duckMinigame = GameObject.Find("duck");
        duckMinigame.SetActive(false);
        //same as above
        peaMinigame = GameObject.Find("PeaParent");
        peaMinigame.SetActive(false);
        //Hide progress bar
        //comment
        scriptHolder = GameObject.Find("ScriptHolder");
        eventSystem = GameObject.Find("Canvas");
        progressBar.transform.localScale = new Vector3(0, 0, 0);
        die.GetComponent<MinigameController>().PauseMinigameTimer();
        currentCameraIndex = 0;

        //Turn all cameras off, except the first default one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }

        //If any cameras were added to the controller, enable the first one
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            Debug.Log("Camera with name: " + cameras[0].GetComponent<Camera>().name + ", is now enabled");
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Start the minigame!
        if (die.GetComponent<MinigameController>().IsMinigameTime())
        {
            
            if (!isPlayingMinigame)
            {
                isPlayingMinigame = true;
                //Should roll to determine minigame here
                currMiniIndex = Random.Range(0, 2);
                switch (currMiniIndex)
                {
                    case 0:
                        runMinigame(duckMinigame);
                        break;
                    case 1:
                        runMinigame(peaMinigame);
                        break;
                }
                Debug.Log("Minigame should begin now!");
                
                
            }
            else if (gameIsWon(duckMinigame) || gameIsWon(peaMinigame))
            {
                isPlayingMinigame = false;
                switch (currMiniIndex)
                {
                    case 0:
                        resetMinigame(duckMinigame);
                        break;
                    case 1:
                        resetMinigame(peaMinigame);
                        break;
                }
            }
        }

        //ew yucky gross nested if
        if (Input.GetKeyDown(KeyCode.C) && !isPlayingMinigame && eventSystem.GetComponent<GameController>().isDone)
        {
            die.GetComponent<MinigameController>().ResetMinigameTimer();
            if (progressBar.transform.localScale == new Vector3(0, 0, 0))
            {
                die.GetComponent<Die>().Roll();
                dieResult = die.GetComponent<Die>().getCurrFace();                      //these two lines super sus
                die.GetComponent<DieSpritePosition>().dieToFront(dieResult);            //^
                Debug.Log("C button has been pressed. Switching to rolled camera");     
                Invoke("swapToRolledCam", 2);
                
            }
            else if (progressBar.GetComponent<Slider>().value >= progressBar.GetComponent<Slider>().maxValue)
            {
                Debug.Log(die.GetComponent<Die>().RollsSoFar);
                Debug.Log("rolling");
                die.GetComponent<Die>().Roll();
                Debug.Log(die.GetComponent<Die>().RollsSoFar);
                dieResult = die.GetComponent<Die>().getCurrFace();                      //these two lines super sus
                die.GetComponent<DieSpritePosition>().dieToFront(dieResult);            //^
                Debug.Log("C button has been pressed. Switching to rolled camera");
                Invoke("swapToRolledCam", 2);
            }
            else
            {
                Debug.Log("Tried to go to next window, but not done at the current one!");
            }
  
        } 
        if (Input.GetKeyDown(KeyCode.V))
        {
            cameras[currentCameraIndex].gameObject.SetActive(false);
            cameras[1].gameObject.SetActive(true);

        }


    }

    void swapToRolledCam()
    {
        die.GetComponent<MinigameController>().ResumeMinigameTimer();
        Debug.Log("prog bar should be true now, curr value is " + progressBar.activeSelf);
        
        //sets last camera to off, turns next camera on based on value from die roll 
        cameras[currentCameraIndex].gameObject.SetActive(false);
        currentCameraIndex = die.GetComponent<Die>().getCurrFace();
        cameras[currentCameraIndex].gameObject.SetActive(true);
        //Show progress bar, just in case it is hidden
        //This is inefficient but unnoticeable at small scale.
        progressBar.transform.localScale = new Vector3(2, 2, 2);
        //TODO: CHANGE BG IMAGE HERE
        Debug.Log(die.GetComponent<Die>().RollsSoFar);
        Debug.Log(((die.GetComponent<Die>().RollsSoFar - 1) * 5) + currentCameraIndex);
        eventSystem.GetComponent<GameController>().ChangeScene(scriptHolder.GetComponent<ScriptHolder>().storyScenes[((die.GetComponent<Die>().RollsSoFar - 1) * 5)  + currentCameraIndex - 1]);
        progressBar.GetComponent<ProgressBar>().Reset();
        Debug.Log("Camera with name: " + cameras[currentCameraIndex].GetComponent<Camera>().name + ", is now enabled");
        //BANDAID FIX, DO NOT DELETE
    }

    private void runMinigame(GameObject game)
    {
        game.SetActive(true);
    }

    private bool gameIsWon(GameObject game)
    {
        string name = game.name;
        switch (name)
        {
            case "duck":
                return game.GetComponent<DuckGame>().gameIsWon;
            case "PeaParent":
                return game.GetComponent<Peas>().gameIsWon;
        }
        return false;
    }

    private void resetMinigame(GameObject game)
    {
        string name = game.name;
        switch (name)
        {
            case "duck":
                duckMinigame.GetComponent<DuckGame>().gameIsWon = false;
                break;
            case "PeaParent":
                peaMinigame.GetComponent<Peas>().gameIsWon = false;
                peaMinigame.GetComponent<Peas>().Reset();
                break;
        }
        game.SetActive(false);
        die.GetComponent<MinigameController>().ResetMinigameTimer();
        die.GetComponent<MinigameController>().ResumeMinigameTimer();
    }
}
