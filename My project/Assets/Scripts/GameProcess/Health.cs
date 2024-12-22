using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject _content;
    [SerializeField] private TextMeshProUGUI _resultScreenText;
    public int StartHealth;
    public int CurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = StartHealth;
    }

    public void TakeDmg(int amount, string nameCard)
    {
        CurrentHealth -= amount;

        if (CurrentHealth <= 0)
        {

            gameObject.SetActive(false);
            Destroy(gameObject);
            OnDead(nameCard);
        }
    }
    private void OnDead(string nameCard)
    {
        if (StartHealth == 100 && nameCard == "Player2")
        {
            this._content.SetActive(true);
            this._resultScreenText.SetText("You Won!");
            this._resultScreenText.color = Color.green;
        }
        if (StartHealth == 100 && nameCard == "Player1")
        {
            this._content.SetActive(true);
            this._resultScreenText.SetText("You died!");
            this._resultScreenText.color = Color.red;
        }
    }

}
