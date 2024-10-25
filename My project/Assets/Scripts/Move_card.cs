using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move_card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {


    public static GameObject m_card;
    public static bool dragged;


    Vector3 m_StartP;
    //Экранная координата
    Vector3 m_StartPS;
    float shiftx;
    float shifty;
    public static Transform m_StartParent;


    public void OnBeginDrag(PointerEventData eventData)
    {

        dragged = true;
        m_card = gameObject;

        m_StartParent=transform.parent;

        m_StartP = transform.position;
        m_StartPS= Camera.main.WorldToScreenPoint(m_StartP);
        shiftx = eventData.position.x - m_StartPS.x;
        shifty = eventData.position.y - m_StartPS.y;
        //Debug.Log("OnDrag");
    }




    #region IDragHandler implementation
    public void OnDrag(PointerEventData eventData)
    {

        Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x-shiftx, eventData.position.y-shifty, (float)0.91));
        transform.position = p;

       
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        dragged = false;
         
        if (transform.parent.GetComponent<m_Ray>().act == false)
        {
            transform.parent = m_StartParent;
            transform.position = m_StartP;
        }
        else transform.localPosition = Vector3.zero;
    }


    #endregion

}
