using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Item : MonoBehaviour
{
    public int cost;
    public string itemName;
    public Button btn;
    // метод совершения покупок
    public void buy()
    {
        //если денег достаточно
        if (GetComponentInParent<Shop>().money >= cost)
        {

            // вычитаем из общего числа монет стоимость покупки
            GetComponentInParent<Shop>().money -= cost;
            GetComponentInParent<Shop>().addItem(itemName);
            btn.gameObject.SetActive(false);
        }
    }
}
