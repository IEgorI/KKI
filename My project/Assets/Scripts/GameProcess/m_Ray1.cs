using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_Ray1: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        coll=GetComponent<Collider>();
    }

   
    Material m_Material;
    Collider coll;

    // Update is called once per frame
    void Update()
    {
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (coll.Raycast(ray, out hit, Mathf.Infinity))
        {
            
           
            if (Move_card.dragged==true)
            {
                Move_card.m_card.transform.SetParent(Move_card.m_StartParent);
            }
        }
        
    }
}
