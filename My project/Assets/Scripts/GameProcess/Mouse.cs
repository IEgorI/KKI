using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        
    }

    public Material Red;
    public Material Blue;
    Material m_Material;
    // Update is called once per frame
    void Update()
    {
        m_Material= GetComponent<Renderer>().material;
    }

    private void OnMouseOver()
    {
       // m_Material.color = Red.color;
    }

    private void OnMouseExit()
    {
      //  m_Material.color= Blue.color;
    }
}
