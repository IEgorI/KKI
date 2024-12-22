using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultScreen : MonoBehaviour
{
    [SerializeField] private Button _StartAgainButton;
    private void Awake()
    {
        this._StartAgainButton.onClick.AddListener(() => 
        {
            SceneManager.LoadScene("SampleScene");
        });
    }
}
