using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public GameObject die;
    public bool isDone = false;
    //[SerializeField] private StoryScene[] scenes = { null, null };



    void Start()
    {
        die = GameObject.Find("Land");
        Debug.Log("calls PlayScene");
        bottomBar.PlayScene(currentScene);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextSentence();
        }
    }

    public void nextSentence()
    {
        if (bottomBar.IsCompleted())
        {
            if (bottomBar.IsLastSentence())
            {
                //ChangeScene(currentScene.nextScene);
                Debug.Log("should see me");
                isDone = true;
                //ChangeScene(currentScene.nextScene);
            }
            bottomBar.PlayNextSentence();
        }
    }

    public void ChangeScene(StoryScene next = null)
    {
        Debug.Log("changing scenes");
        //currentScene.nextScene = scenes[/*die.GetComponent<Die>().getCurrFace()*/1]; 
        isDone = false;
        bottomBar.PlayScene(next);
        /*if (!next)
        {
            //bottomBar.PlayScene(next);
            currentScene.nextScene = next;
        }
        else
        {
            currentScene = currentScene.nextScene;
        }
        bottomBar.PlayScene(next);
        */
    }
}
