using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;


    //tells us if we have displayed everything or not
    private enum State
    {
        PLAYING, COMPLETED
    }

    public void PlayScene(StoryScene scene)
    {
        Debug.Log("play scene");
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }


    public void PlayNextSentence()
    {
        Debug.Log("play next sentence");
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
    }

    public bool IsCompleted()
    {
        Debug.Log("iscomplete");
        return state == State.COMPLETED; 
    }

    public bool IsLastSentence()
    {
        Debug.Log("is last sentence");
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    //I believe this bit is what runs the text at a delay
    private IEnumerator TypeText(string text)
    {
        Debug.Log("Ienumerator");
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;
        Debug.Log(text);
        while(state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if(++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
}
