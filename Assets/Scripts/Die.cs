using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    [SerializeField] private int[] Faces = { 1, 2, 3, 4, 5, 6 };
    [SerializeField] private int currFace;
    private GameObject parentObj = GameObject.Find("Die");
    // Start is called before the first frame update
    void Start()
    {
        Roll();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Roll();
        }
    }

    void Roll()
    {
        currFace = Faces[Random.Range(0, Faces.Length - 1)];
        switch (currFace)
        {
            case 1:
                GetComponent<Renderer>().material.color = new Color(0, 255, 0);
                break;
            case 2:
                GetComponent<Renderer>().material.color = new Color(255, 0, 0);
                break;
            case 3:
                GetComponent<Renderer>().material.color = new Color(0, 0, 255);
                break;
            case 4:
                GetComponent<Renderer>().material.color = new Color(125, 125, 0);
                break;
            case 5:
                GetComponent<Renderer>().material.color = new Color(125, 0, 125);
                break;
            case 6:
                GetComponent<Renderer>().material.color = new Color(0, 0, 0);
                break;
        }
        
    }
}
