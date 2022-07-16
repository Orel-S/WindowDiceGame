using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraSwap : MonoBehaviour
{

    public Camera[] cameras;
    private int currentCameraIndex;
    public GameObject die, progressBar;

    // Start is called before the first frame update
    void Start()
    {

        die = GameObject.Find("Land");
        progressBar = GameObject.Find("ProgressBar");
        //Hide progress bar
        progressBar.transform.localScale = new Vector3(0, 0, 0);
        die.GetComponent<MinigameChancemaker>().PauseMinigameTimer();
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
        if (die.GetComponent<MinigameChancemaker>().IsMinigameTime())
        {
            Debug.Log("Minigame should begin now!");
        }

        //ew yucky gross nested if
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (progressBar.transform.localScale == new Vector3(0, 0, 0))
            {
                Debug.Log("obj no exist");
                die.GetComponent<Die>().Roll();
                Invoke("swapToRolledCam", 2);
                
            }
            else if (progressBar.GetComponent<Slider>().value >= progressBar.GetComponent<Slider>().maxValue)
            {
                die.GetComponent<Die>().Roll();
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
        die.GetComponent<MinigameChancemaker>().ResumeMinigameTimer();
        Debug.Log("prog bar should be true now, curr value is " + progressBar.activeSelf);
        Debug.Log("C button has been pressed. Switching to rolled camera");
        //sets last camera to off, turns next camera on based on value from die roll 
        cameras[currentCameraIndex].gameObject.SetActive(false);
        currentCameraIndex = die.GetComponent<Die>().getCurrFace();
        cameras[currentCameraIndex].gameObject.SetActive(true);
        //Show progress bar, just in case it is hidden
        //This is inefficient but unnoticeable at small scale.
        progressBar.transform.localScale = new Vector3(2, 2, 2);

        progressBar.GetComponent<ProgressBar>().Reset();
        Debug.Log("Camera with name: " + cameras[currentCameraIndex].GetComponent<Camera>().name + ", is now enabled");
        //BANDAID FIX, DO NOT DELETE
    }

}
