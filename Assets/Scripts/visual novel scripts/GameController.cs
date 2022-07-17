using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public GameObject die;
    [SerializeField] private StoryScene[] scenes = { null, null };



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
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.IsLastSentence())
                {
                    Debug.Log("changing scenes");
                    currentScene.nextScene = scenes[/*die.GetComponent<Die>().getCurrFace()*/1]; 
                    //currentScene = currentScene.nextScene;
                    bottomBar.PlayScene(currentScene);
                }
                bottomBar.PlayNextSentence();
            }
        }
    }
}
