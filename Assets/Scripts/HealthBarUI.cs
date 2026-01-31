using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private RectTransform m_bar;
    [SerializeField]
    private float m_width, m_height;

    private float m_health, m_maxHealth;

    public void setHealth(float t_health)
    {
        m_health = t_health;
        float newWidth = (m_health / m_maxHealth) * m_width;

        m_bar.sizeDelta = new Vector2 (newWidth, m_height);
    }

    public void setMax(float t_max)
    {
        m_maxHealth = t_max;
    }
}
