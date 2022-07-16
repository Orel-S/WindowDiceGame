using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpritePosition : MonoBehaviour
{

    [SerializeField] private GameObject[] dice = { null, null, null, null, null, null} ;
    private int currentDieFace;
    public GameObject diceywicey;
    private Vector3 diePos;

    // Start is called before the first frame update
    void Start()
    {

        diceywicey = GameObject.Find("Land");

        //set all dice back except 1
        for (int i = 1; i<6; i++)
        {
            Debug.Log("die face one should be in front");
            dice[i].transform.position = new Vector3(0,0,11);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dieToFront(int dieResult)
    {

        Debug.Log("die face should update");
        for (int i = 0; i < 6; i++)
        {
            dice[i].transform.position = new Vector3(0, 0, 11);
        }
        dice[dieResult - 1].transform.position = new Vector3(9, 3, 8);

    }

}
