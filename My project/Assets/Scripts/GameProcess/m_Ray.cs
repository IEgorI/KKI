using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class m_Ray : MonoBehaviour
{

    public bool act = false;
    public Material Red;
    public Material Blue;
    Material m_Material;
    Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        coll=GetComponent<Collider>();
    }

    

    // Update is called once per frame
    void Update()
    {
        Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (coll.Raycast(ray,out hit,Mathf.Infinity))
        {
            if ((gameObject.layer==10 && !GMscript.turn) || (gameObject.layer == 9 && GMscript.turn))
            {
                if (transform.childCount==0)
                {
                    act = true;
                    m_Material.color = Red.color;
                }
               
            }
           
           
            if (Move_card.dragged==true)
            {
                Move_card.m_card.transform.SetParent(transform);
            }
        }
        else
        {
            act = false;
            m_Material.color = Blue.color;
        }
    }
}
