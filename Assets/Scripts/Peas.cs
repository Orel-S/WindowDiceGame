using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peas : MonoBehaviour

{
    [SerializeField] private GameObject[] peas = { null, null, null, null, null };
    public GameObject PissFinder;
    public int currentPea;

    // Start is called before the first frame update
    void Start()
    {
        PissFinder = GameObject.Find("PeaParent");
        

    }

    // Update is called once per frame
    void Update()
    {
        if (peas[currentPea].active != true)
        {
            currentPea++;
        }
    }

    public void isClicked()
    {
        
        Debug.Log("That was easy!");
        peas[currentPea].SetActive(false);
        //currentPea++;
    }
}
