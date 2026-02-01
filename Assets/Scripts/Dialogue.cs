using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    TextMeshProUGUI m_text;

    [SerializeField]
    GameState m_gameStateRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_text = GetComponentInChildren<TextMeshProUGUI>();
        PlayerTurn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayDamage(float t_amount, string t_title, string t_target)
    {
        m_text.text = t_title + " dealt " + Mathf.RoundToInt(t_amount).ToString() + " damage to " + t_target + "!";
    }

    public void DisplayDeath(string t_title)
    {
        m_text.text = t_title + " has died!";
    }

    public void DisplayFlee()
    {
        m_text.text = "Failed to flee from battle";
        m_gameStateRef.TurnEnd();
    }
    public void PlayerTurn()
    {
        m_text.text = "";
    }
}
