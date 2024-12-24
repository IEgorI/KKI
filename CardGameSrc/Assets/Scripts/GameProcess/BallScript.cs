using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameObject ball;
    public int force;
  

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            GameObject go = (GameObject)Instantiate (ball);
            go.GetComponent<Rigidbody>().AddForce(go.transform.right*force);
        }  
    }
}
