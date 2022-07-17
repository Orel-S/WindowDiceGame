using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peas : MonoBehaviour

{
    [SerializeField] private GameObject[] peas = { null, null, null, null, null };
    public GameObject PeaFinder;
    [SerializeField] public int currentPea;
    public int PeasPopped = 0;
    private int peaCap = 5;
    public bool gameIsWon = false;

    // Start is called before the first frame update
    void Start()
    {
        PeaFinder = GameObject.Find("PeaParent");
        randomizePeaLocations();
    }

    // Update is called once per frame
    void Update()
    {
        if (PeasPopped >= peaCap)
        {
            gameIsWon = true;
        }
    }

    public void isClicked()
    {
        
        Debug.Log("That was easy!");
        gameObject.transform.parent.gameObject.GetComponent<Peas>().PeasPopped += 1;
        peas[currentPea].SetActive(false);
    }

    public void Reset()
    {
        PeasPopped = 0;
        randomizePeaLocations();
        for (int i = 0; i < peaCap; i++)
        {
            peas[i].SetActive(true);
        }
    }

    private void randomizePeaLocations()
    {
        foreach (GameObject pea in peas)
        {
            pea.transform.localPosition = new Vector3(0, 0, 0);
            pea.transform.localPosition += new Vector3(Random.Range(-300, 300), Random.Range(-300, 300), 0);
        }
    }
}
