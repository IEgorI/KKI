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
    // ����� ���������� �������
    public void buy()
    {
        //���� ����� ����������
        if (GetComponentInParent<Shop>().money >= cost)
        {

            // �������� �� ������ ����� ����� ��������� �������
            GetComponentInParent<Shop>().money -= cost;
            GetComponentInParent<Shop>().addItem(itemName);
            btn.gameObject.SetActive(false);
        }
    }
}
