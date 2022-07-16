using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameChancemaker : MonoBehaviour
{

    private float increaseRate = 0.01f;
    private float currRate = 0.0001f;
    private float currOdds = 0;
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
    }

    //hint for Will, code should look something like this:
    //public GameObject fuunyFakeVariableName = GameObject.Find("objName");
    //fuunyFakeVariableName.GetComponent<MinigameChancemaker>().IsMinigameTime();
    public bool IsMinigameTime()
    {
        if(currOdds >= 1)
        {
            currOdds = 0;
            currRate = 0.0001f;
            return true;
        }
        return false;
    }
}
