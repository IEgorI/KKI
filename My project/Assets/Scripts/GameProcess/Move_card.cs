using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Move_card : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {


    public static GameObject m_card;
    public static bool dragged;

    bool draggable = true;


    public static Vector3 m_StartP;
    //Экранная координата
    public static Vector3 m_StartPS;
    float shiftx;
    float shifty;
    public static Transform m_StartParent;

    IEnumerator DelayedAction()
    {
        // Ждем 2 секунды
        yield return new WaitForSeconds(1000f);

        // Код, который выполняется после задержки
        Debug.Log("Задержка завершена!");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (draggable==true)
      
        {
            if ((gameObject.layer == 10 && !GMscript.turn) || (gameObject.layer == 9 && GMscript.turn))
            {
                dragged = true;
                m_card = gameObject;

                m_StartParent = transform.parent;

                m_StartP = transform.position;
                m_StartPS = Camera.main.WorldToScreenPoint(m_StartP);
                shiftx = eventData.position.x - m_StartPS.x;
                shifty = eventData.position.y - m_StartPS.y;
                //Debug.Log("OnDrag");
            }
        }
    }

    #region IDragHandler implementation
    public void OnDrag(PointerEventData eventData)
    {
        if (draggable==true)
        {
            if ((gameObject.layer == 10 && !GMscript.turn) || (gameObject.layer == 9 && GMscript.turn))
            {

                Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(eventData.position.x - shiftx, eventData.position.y - shifty, (float)0.91));
                transform.position = p;

            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (draggable == true)
        {
            if ((gameObject.layer == 10 && !GMscript.turn) || (gameObject.layer == 9 && GMscript.turn))

            {
                dragged = false;

                if (transform.parent.GetComponent<m_Ray>().act == false)
                {
                    transform.parent = m_StartParent;
                    transform.position = m_StartP;
                }
                else
                {
                    transform.localPosition = Vector3.zero;
                    draggable = false;
                    gameObject.GetComponent<AutoAttack>().ActCard = true;
                    GMscript.turn = !GMscript.turn;
                }
            }
        }
    }

    public static void comeback()
    {
        m_card.transform.parent = m_StartParent;
        m_card.transform.position = m_StartP;
        dragged = false;
    }

    #endregion

}

