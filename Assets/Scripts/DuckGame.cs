using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckGame : MonoBehaviour
{
    public GameObject eye1, eye2;
    public bool gameIsWon = false;
    // Start is called before the first frame update
    void Start()
    {
        eye1 = GameObject.Find("MinigameEyeball1");
        eye2 = GameObject.Find("MinigameEyeball2");
    }

    // Update is called once per frame
    void Update()
    {
        if (eye1.GetComponent<Eyeball>().playerHasWon)
        {
            gameIsWon = true;
            eye1.GetComponent<Eyeball>().playerHasWon = false;
            eye1.GetComponent<Eyeball>().ContProgress();
            eye2.GetComponent<Eyeball>().playerHasWon = false;
            eye2.GetComponent<Eyeball>().ContProgress();
        }
    }
}
