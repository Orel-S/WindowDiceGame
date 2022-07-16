using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eyeball : MonoBehaviour
{
    private Slider slider;
    public float FillSpeed = 0;
    private float defaultFillSpeed = 3.2f;
    private bool isIncreasing = true;
    private float minWin = 0.35f;
    private float maxWin = 0.65f;
    public bool playerHasWon = false;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = Random.Range(0, 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        ContProgress();
    }

    // Update is called once per frame
    void Update()
    {
        //Check for winning
        if (Input.GetKeyDown(KeyCode.Space) && FillSpeed != 0)
        {
            if(slider.value >= minWin && slider.value <= maxWin)
            {
                Debug.Log("You win the eye game!");
                PauseProgress();
                playerHasWon = true;
            }
            else
            {
                Debug.Log("nope, you missed!");
                PauseProgress();
                Invoke("ContProgress", 0.5f);
            }
        }
            //Flip if needed, increase/decrease value
        if (slider.value == slider.maxValue || slider.value == slider.minValue)
        {
            //flip if maxed or min'd
            isIncreasing = !isIncreasing;
        }
        if (slider.value < slider.maxValue && isIncreasing)
        {
            slider.value += FillSpeed * Time.deltaTime;
        }
        else
        {
            slider.value -= FillSpeed * Time.deltaTime;
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
}
