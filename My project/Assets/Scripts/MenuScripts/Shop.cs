using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int money;
    public string[] result;
    public Text moneyText;
    public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    Connection conn = new Connection();
    void Start()
    {
        money = GlobalData.coins;
        moneyText.text = money.ToString();
        if (GlobalData.prov1 == true) btn1.gameObject.SetActive(false);
        if (GlobalData.prov2 == true) btn2.gameObject.SetActive(false);
        if (GlobalData.prov3 == true) btn3.gameObject.SetActive(false);
        if (GlobalData.prov4 == true) btn4.gameObject.SetActive(false);
    }
    void Update()
    {
        result = conn.setConnectionDb();
        money = int.Parse(result[4]);
        moneyText.text = money.ToString();
    }
    // этот метод выводит построчно названия покупок в инвентаре
    public void addItem(string item)
    {
        if (item == "Card_6") GlobalData.prov1 = true;
        if (item == "Card_9") GlobalData.prov2 = true;
        if (item == "Card_10") GlobalData.prov3 = true;
        if (item == "Card_15") GlobalData.prov4 = true;
        GlobalData.coins = GlobalData.coins - 100;
        conn.updateConnectionDb(money);
        string[] res = conn.setConnectionDb();
        money = int.Parse(res[4]);
        moneyText.text = money.ToString();
    }
}
