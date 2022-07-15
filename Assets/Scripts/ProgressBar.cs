using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;
    private float targetProgress = 0;
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
        IncrementProgress(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.PageUp))
        {
            ContProgress();
        }
        if (Input.GetKeyDown(KeyCode.PageDown))
        {
            PauseProgress();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Reset();
        }
        if (slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
        }
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
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

    //Sloppy code, figure out this weird reset shit
    public void Reset()
    {
        slider.value = 0;
        FillSpeed = 0.05f;
        defaultFillSpeed = 0.05f;
    }
}
