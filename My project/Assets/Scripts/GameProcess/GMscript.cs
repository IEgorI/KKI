using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GMscript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool turn;
    public static bool turnNew;

    public TextMesh Txt;
    public TextMesh eTxt;
    string text;
    int startTime = 16;
    int curTime=10;
    public CardBase cardbase;
    Connection conn = new Connection();
    public GameObject Card_1, Card_2, Card_3, Card_4, Card_5, Card_6, Card_7, Card_8, Card_9, Card_10, Card_11, Card_12, Card_13, Card_14, Card_15, Card_16, Card_17;
    public List<GameObject> enem=new List<GameObject>();

    int[,] cell = new int[,]
    {
        {0, 0, 0, 0 },
        {0, 0, 0, 0 },
        {0, 0, 0, 0 },
        {0, 0, 0, 0 }


    };
    int[,] ecell = new int[,]
   {
        {0, 0, 0, 0 },
        {0, 0, 0, 0 },
        {0, 0, 0, 0 },
        {0, 0, 0, 0 }


   };

    void Start()
    {
        deal();
        deal2();
        StartCoroutine(Timer());
        Debug.Log(cardbase.CardName[0]);
    }


     void Update()
    {
        if (!turn)
        {
            //eMove();
        }
       
    }
    IEnumerator Timer() //таймер главного героя
    {
        tChange();
        yield return new WaitForSecondsRealtime (1);
        if (curTime > 0 && turn)
        {
            StartCoroutine(Timer());
        }
        else
        {
            Txt.text = "";
            curTime = 10;
            if (Move_card.dragged==true)
            {
                Move_card.comeback();
            }
            deal();
            StartCoroutine(eTimer()); //переход таймера на врага
            eMove();
            turn = true;
            turnNew = true;

        }
       
    }
    IEnumerator eTimer() //таймер врага
    {
        etChange();
        yield return new WaitForSecondsRealtime(1);
        if (curTime > 0 && !turn)
        {
            StartCoroutine(eTimer());
        }
        else
        {
            eTxt.text = "";
            curTime = 10;
            if (Move_card.dragged == true)
            {
                Move_card.comeback();
            }
            turn = true;
            deal2();
            StartCoroutine(Timer()); //переход таймера на главного героя
            turnNew = false;

        }

    }
    void tChange()  //происходит смена текста на таймере главного героя
    {
        --curTime;
        text=curTime.ToString();
        Txt.text = text;
        
    }
    void etChange() //происходит смена текста на таймере врага
    {
        --curTime;
        text = curTime.ToString();
        eTxt.text = text;

    }

    void deal() //раздача карт для главного героя
    {
        string[] res = conn.setConnectionDb();
        int prov1 = int.Parse(res[0]);
        int prov2 = int.Parse(res[1]);
        int prov3 = int.Parse(res[2]);
        int prov4 = int.Parse(res[3]);
        GameObject[] card = new GameObject[] { Card_1, Card_2, Card_3, Card_4, Card_5, Card_6, Card_7, Card_8, Card_9, Card_10, Card_11, Card_12, Card_13, Card_14, Card_15, Card_16, Card_17 };
        for (int i = 0; i < 4; i++)
        {
            if (GameObject.Find("c" + i.ToString() + "0").transform.childCount == 0)
            {
                // Данный код проверяет 4 карты в магазине и если они не куплены не выставляет их на поле
                int number = 0;
                while (true)
                {
                    number = Random.Range(0, 17);
                    if ((number == 5 && prov1 == 0) || (number == 8 && prov2 == 0) || (number == 9 && prov3 == 0) || (number == 14 && prov4 == 0))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                GameObject go = Instantiate(card[number]) as GameObject;
                go.transform.parent = GameObject.Find("c"+i.ToString()+"0").transform;
                go.transform.localPosition = Vector3.zero;
                go.layer = 9; //половина поля для главного героя
                go.GetComponent<Attack>().dir = Vector3.right;
                go.GetComponent<Attack>().AttTurn = true;
                //cell[i, 0] = 1;
            }
        }
    }
    void deal2() //раздача карт для врага
    {
        GameObject[] card = new GameObject[] { Card_1, Card_2, Card_3, Card_4, Card_5, Card_6, Card_7, Card_8, Card_9, Card_10, Card_11, Card_12, Card_13, Card_14, Card_15, Card_16, Card_17 };
        for (int i = 0; i < 4; i++)
        {
            if (GameObject.Find("e" + i.ToString() + "0").transform.childCount == 0)
            {
                int number = 0;
                number = Random.Range(0, 17);
                GameObject go = Instantiate(card[number]) as GameObject;
                go.transform.parent = GameObject.Find("e" + i.ToString() + "0").transform;
                go.transform.localPosition = Vector3.zero;
                go.layer = 10; //половина поля для врага
                go.GetComponent<Attack>().dir = Vector3.left;
                go.GetComponent<Attack>().AttTurn = false;
                //ecell[i, 0] = 1;
            }
        }
    }

    void eMove() //Бот
    {
        int i = Random.Range(0, 4);
        GameObject go = GameObject.Find("e" + i.ToString() + "0").transform.GetChild(0).gameObject;
        Debug.Log(go);
        GameObject cell;
        do
        {
            i = Random.Range(0, 12);
            cell = GameObject.Find("eCell(" + i.ToString() + ")");
        }
        while (cell.transform.childCount!=0);
        go.transform.parent = cell.gameObject.transform;
        go.transform.localPosition =  new Vector3();
        go.GetComponent<AutoAttack>().ActCard = true;
        turn = true;
        enem.Add(go);

    }
}
