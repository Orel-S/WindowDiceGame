using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        GameObject gom = GameObject.Find("GoodbyeSound");
        gom.GetComponent<AudioSource>().Play();

        Invoke("actualQuit", 3);
    }

    private void actualQuit()
    {
        Application.Quit();
    }
}
