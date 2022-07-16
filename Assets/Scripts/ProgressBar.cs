using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    public float FillSpeed = 0;
    private float defaultFillSpeed = 0.05f;
    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        FillSpeed = defaultFillSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            slider.value = 1;
            Debug.Log("slider bar should be full");
        }

        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            ContProgress();
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            PauseProgress();
        }
        //if (Input.GetKeyDown(KeyCode.C))
        //{
        //    Reset();
        //}
        if (slider.value < 1)
        {
            slider.value += FillSpeed * Time.deltaTime;
        }
    }

    public void PauseProgress()
    {
        defaultFillSpeed = FillSpeed;
        FillSpeed = 0;
    }

    public void ContProgress()
    {
        FillSpeed = defaultFillSpeed;
    }

    public void setSpeed(float speed)
    {
        FillSpeed = speed;
    }

    //Sloppy code, figure out this weird reset shit
    public void Reset()
    {
        slider.value = 0;
        FillSpeed = 0.05f;
        defaultFillSpeed = 0.05f;
    }
}
