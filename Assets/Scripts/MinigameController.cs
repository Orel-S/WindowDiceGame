using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{

    private float increaseRate = 0.01f;
    private float currRate = 0.01f; //was 0.0001f
    //temp, switch back to 0
    private float currOdds = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //add rand here
        currOdds += currRate;
        currOdds += (currRate * Random.Range(1, 5)) * Time.deltaTime;
        //Debug.Log(currOdds);
    }

    //hint for Will, code should look something like this:
    //public GameObject fuunyFakeVariableName = GameObject.Find("objName");
    //fuunyFakeVariableName.GetComponent<MinigameChancemaker>().IsMinigameTime();
    public bool IsMinigameTime()
    {
        if(currOdds >= 1)
        {
            PauseMinigameTimer();
            return true;
        }
        return false;
    }

    public void PauseMinigameTimer()
    {
        increaseRate = 0;
        currRate = 0;

    }

    public void ResumeMinigameTimer()
    {
        increaseRate = 0.01f;
        currRate = 0.0001f;
    }

    public void ResetMinigameTimer()
    {
        currOdds = 0;
    }

}
