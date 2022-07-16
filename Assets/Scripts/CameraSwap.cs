using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CameraSwap : MonoBehaviour
{

    public Camera[] cameras;
    private int currentCameraIndex;
    public GameObject landyboiimwillandimdumb;

    // Start is called before the first frame update
    void Start()
    {

        landyboiimwillandimdumb = GameObject.Find("Land");

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

        if (Input.GetKeyDown(KeyCode.C))
        {

            Invoke("swippitySwappityGetOffMyProperty", 2); 
  
        }

    }

    void swippitySwappityGetOffMyProperty()
    {
        Debug.Log("C button has been pressed. Switching to rolled camera");
        //sets last camera to off, turns next camera on based on value from die roll 
        cameras[currentCameraIndex].gameObject.SetActive(false);
        currentCameraIndex = landyboiimwillandimdumb.GetComponent<Die>().getCurrFace();
        cameras[currentCameraIndex].gameObject.SetActive(true);
        Debug.Log("Camera with name: " + cameras[currentCameraIndex].GetComponent<Camera>().name + ", is now enabled");
    }

}
