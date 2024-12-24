using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCards : MonoBehaviour
{
    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;
    // Start is called before the first frame update
    public void Update()
    {
        if (GlobalData.prov1 == true) card1.SetActive(true);
        if (GlobalData.prov2 == true) card2.SetActive(true);
        if (GlobalData.prov3 == true) card3.SetActive(true);
        if (GlobalData.prov4 == true) card4.SetActive(true);     
    }   
}
