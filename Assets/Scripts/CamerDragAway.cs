using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamerDragAway : MonoBehaviour
{
    public float panSpeed = 1f;
    private int[] Faces = { 1, 2, 3, 4, 5 };
    private int currFace = 1;
    Quaternion rot;
    private float startY, startX;
    private float maxRotVal = 0.20f;



    void Start()
    {
        rot = transform.rotation;
        startY = rot.y;
        startX = rot.x;
    }
    
        // Update is called once per frame
    void Update()
    {
        

        

        switch (currFace)
        {
            case 1:
                rot.y -= panSpeed * (Time.deltaTime / 7);
               // Debug.Log("diff is " + Math.Abs(rot.y - startY));
                if(Math.Abs(rot.y - startY) >= maxRotVal)
                {
                    currFace = Faces[UnityEngine.Random.Range(0, Faces.Length - 1)];
                    Debug.Log(currFace);
                }
                break;
            case 2: 
                rot.y += panSpeed * (Time.deltaTime / 7);
                if(Math.Abs(rot.y - startY) >= maxRotVal)
                {
                    currFace = Faces[UnityEngine.Random.Range(0, Faces.Length - 1)];
                    Debug.Log(currFace);
                }
                break;
            case 3:
                rot.x -= panSpeed * (Time.deltaTime / 7);
                if (Math.Abs(rot.x - startX) >= maxRotVal)
                {
                    currFace = Faces[UnityEngine.Random.Range(0, Faces.Length - 1)];
                    Debug.Log(currFace);
                }
                break;
            case 4: rot.x += panSpeed * (Time.deltaTime / 7);
                if(Math.Abs(rot.x - startX) >= maxRotVal)
                {
                    currFace = Faces[UnityEngine.Random.Range(0, Faces.Length - 1)];
                    Debug.Log(currFace);
                }
                break;


        }
        

        /* if (Input.GetKey("a"))
        {
            rot.y -= panSpeed * (Time.deltaTime / 7);
        } else if (Input.GetKey("d"))
        {
            rot.y += panSpeed * (Time.deltaTime / 7);
        } else if (Input.GetKey("w"))
        {
            rot.x -= panSpeed * (Time.deltaTime / 7);
        } else if (Input.GetKey("s")){
            rot.x += panSpeed * (Time.deltaTime / 7);
        } */


        transform.rotation = rot;

    }
}
