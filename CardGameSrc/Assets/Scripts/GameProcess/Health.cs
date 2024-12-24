using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int StartHealth;
    public int CurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = StartHealth;
    }

    public void TakeDmg(int amount)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {

            gameObject.SetActive(false);
            Destroy(gameObject);

        }



    }
    
}
