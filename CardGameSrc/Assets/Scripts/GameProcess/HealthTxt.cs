using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTxt : MonoBehaviour
{


    public GameObject owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public void HTchange()
    {
        owner = gameObject.transform.parent.parent.gameObject;
        int txt=owner.GetComponent<Health>().CurrentHealth;
        GetComponent<TextMesh>().text = txt.ToString();
    }
}
