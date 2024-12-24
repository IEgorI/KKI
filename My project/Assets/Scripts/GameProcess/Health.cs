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
    Connection conn = new Connection();
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
            this._resultScreenText.SetText("Âû ÏÎÁÅÄÈËÈ!");
            this._resultScreenText.color = Color.green;
            GlobalData.coins += 40;
            conn.updateConnectionDb(GlobalData.coins);
            return;
        }
        if (StartHealth == 100 && nameCard == "Player1")
        {
            this._content.SetActive(true);
            this._resultScreenText.SetText("Âû ÏÐÎÈÃÐÀËÈ!");
            this._resultScreenText.color = Color.red;
            return;
        }
    }

}
