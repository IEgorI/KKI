using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GMscript : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool turn;

    public TextMesh Txt;
    public TextMesh eTxt;
    string text;
    int startTime = 16;
    int curTime=16;

    public bool prov1, prov2, prov3, prov4 = false;
    public CardBase cardbase;
    public GameObject Card_1, Card_2, Card_3, Card_4, Card_5, Card_6, Card_7, Card_8, Card_9, Card_10, Card_11, Card_12, Card_13, Card_14, Card_15, Card_16, Card_17;

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
        turn = (Random.value > 0.5); //происходит выбор 1 хода
        deal();
        deal2();
        if (turn) StartCoroutine(Timer()); //первый ход главного героя
        else StartCoroutine(eTimer()); //первый ход врага
        Debug.Log(cardbase.CardName[0]);
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
            curTime = 16;
            if (Move_card.dragged==true)
            {
                Move_card.comeback();
            }
            turn=false;
            
            StartCoroutine(eTimer()); //переход таймера на врага
            deal();

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
            curTime = 16;
            if (Move_card.dragged == true)
            {
                Move_card.comeback();
            }
            turn = true;
            
            StartCoroutine(Timer()); //переход таймера на главного героя
            deal2();

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
                    if ((number == 5 && prov1 == false) || (number == 8 && prov2 == false) || (number == 9 && prov3 == false) || (number == 14 && prov4 == false))
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
                // Данный код проверяет 4 карты в магазине и если они не куплены не выставляет их на поле
                int number = 0;
                while (true)
                {
                    number = Random.Range(0, 17);
                    if ((number == 5 && prov1 == false) || (number == 8 && prov2 == false) || (number == 9 && prov3 == false) || (number == 14 && prov4 == false))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
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
}
