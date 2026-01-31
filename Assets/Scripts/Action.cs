using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Action : MonoBehaviour
{
    [SerializeField]
    GameState m_gameStateRef;
        
    public UnityEvent m_damageDealt;

    private float m_damage;
    private float m_agility;
    private string m_parentTitle;
    private int m_cost;
    private Health m_target;
    private string m_targetName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_parentTitle = GetComponentInParent<CharacterData>().GetTitle();
        m_damageDealt.AddListener(() => GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Dialogue>().DisplayDamage(m_damage, m_parentTitle, m_targetName));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Execute(State t_target, float t_damage, int t_cost)
    {
        m_damage = t_damage;
        m_cost = t_cost;

        m_target = m_gameStateRef.GetTarget(t_target);
        m_targetName = m_gameStateRef.GetTargetName(t_target);
        m_target.Damage(m_damage);

        m_damageDealt.Invoke();

        m_gameStateRef.TurnEnd();
    }

    public void Flee(State t_target, float t_agility)
    {
        m_agility = m_gameStateRef.GetTargetAgility(t_target);

        if (t_agility > m_agility)
        {

        }
    }
}


