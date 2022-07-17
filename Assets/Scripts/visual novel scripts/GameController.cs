using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    
    void Start()
    {
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
                bottomBar.PlayNextSentence();
            }
        }
    }
}
