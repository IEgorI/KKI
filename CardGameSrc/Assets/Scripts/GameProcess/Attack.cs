 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngineInternal;

public class Attack : MonoBehaviour
{

    public float dist;
    public GameObject target;
    public GameObject TrgTxt;
    public int Dmg;
    public Vector3 dir;
    public GameObject ball;
    public int force = 3000;
    int layerMask;
    public bool AttTurn;


    void Update()
    {
        if (gameObject.GetComponent<AutoAttack>().ActCard)
        {
            if (GMscript.turn == AttTurn)
            {
                ATT();
                AttTurn = !AttTurn;
            }
        }
    }
    public void ATT()
    {
        
            layerMask = ~(1 << gameObject.layer);
            FindTrg();
            if (target)
            {
                Health TargetHealt = target.GetComponent<Health>();
                vfx();
                TargetHealt.TakeDmg(Dmg);
                HealthTxt that = TrgTxt.GetComponent<HealthTxt>();
                that.HTchange();
            }
        
    }

    void FindTrg()
    {
        Ray ray = new Ray(transform.position, dir);
        Debug.DrawRay(transform.position,dir*dist,Color.blue);
        RaycastHit hit;
        Physics.Raycast(ray,out hit, dist, layerMask);
        if (hit.collider)
        {
            target = hit.collider.gameObject;
            TrgTxt = target.transform.GetChild(0).GetChild(0).gameObject;
        }
        else
        {
            target = null;
        }
       

    }
    void vfx()
    {
        GameObject go = (GameObject)Instantiate(ball, transform.position, transform.rotation);
        if (dir == Vector3.right)
        {
            go.GetComponent<Rigidbody>().AddForce(go.transform.right * force);
        }
        else
        {
            go.GetComponent<Rigidbody>().AddForce(go.transform.right * -force);
        }
    }

}
