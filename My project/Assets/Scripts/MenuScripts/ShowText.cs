using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowText : MonoBehaviour
{
    [SerializeField] GameObject CardText;
    void Start()
    {
        CardText.SetActive(false);
    }

    public void OnMouseOver()
    {
        CardText.SetActive(true);
    }

    public void OnMouseExit()
    {
        CardText.SetActive(false);
    }

}
