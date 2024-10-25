using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public CardBase cardbase;
    public GameObject Card_1;
    public GameObject Card_2;
    int[,] cell = new int[,]
    {
        {0, 0, 0, 0 },
        {0, 0, 0, 0 },
        {0, 0, 0, 0 },
        {0, 0, 0, 0 }


    };
    
    void Start()
    {
        deal();
        Debug.Log(cardbase.CardName[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void deal()
    {
        GameObject[] card = new GameObject[] { Card_1, Card_2 };
        for (int i = 0; i < 4; i++)
        {
            if (cell [i, 0] == 0)
            {
                int number = Random.Range(0, 2);
                GameObject go = Instantiate(card[number]) as GameObject;
                go.transform.parent = GameObject.Find("c"+i.ToString()+"0").transform;
                go.transform.localPosition = Vector3.zero;
                cell[i, 0] = 1;
            }
        }
    }
}
