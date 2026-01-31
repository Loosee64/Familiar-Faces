using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField]
    private HealthBarUI m_healthBarUI;
    
    private TextMeshProUGUI m_text;

    int m_health;
    private int m_maxHealth;
    int m_defense;

    private void Awake()
    {
        m_text = m_healthBarUI.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetDefense(int t_defense)
    {
        m_defense = t_defense;
    }

    public void FullHeal()
    {
        m_health = m_maxHealth;
        m_healthBarUI.setHealth(m_health);
    }

    public void setMax(int t_amount)
    {
        m_maxHealth = t_amount;
        m_health = m_maxHealth;
        m_healthBarUI.setMax(m_maxHealth);
        m_text.text = "HP: " + m_health.ToString() + "/" + m_maxHealth.ToString();
    }

    public void Damage(float t_damage)
    {
        if (m_health > 0)
        {
            t_damage -= m_defense / 2;
            m_health -= Mathf.RoundToInt(t_damage);
            m_healthBarUI.setHealth(m_health);
            m_text.text = "HP: " + m_health.ToString() + "/" + m_maxHealth.ToString();
            Debug.Log("damage");
        }
    }

    public bool IsAlive()
    {
        if (m_health > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
