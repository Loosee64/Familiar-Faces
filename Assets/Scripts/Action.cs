using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Action : MonoBehaviour
{
    [SerializeField]
    GameState m_gameStateRef;
        
    public UnityEvent m_damageDealt;
    public UnityEvent fleeFail;

    private float m_damage;
    private float fleeAgility;
    private string m_parentTitle;
    private int m_cost;
    private Health m_target;
    private string m_targetName;
    State fleeTarget;
    float agility;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_parentTitle = GetComponentInParent<CharacterData>().GetTitle();
        m_damageDealt.AddListener(() => GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Dialogue>().DisplayDamage(m_damage, m_parentTitle, m_targetName));
        fleeFail.AddListener(GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Dialogue>().DisplayFlee);
    }

    public void Execute(State t_target, float t_damage, int t_cost)
    {
        m_damage = t_damage;
        m_cost = t_cost;

        m_target = m_gameStateRef.GetTarget(t_target);
        m_targetName = m_gameStateRef.GetTargetName(t_target);
        m_damage -= (m_gameStateRef.GetTargetDefense(t_target) - 1) / 2;
        m_target.Damage(m_damage);

        m_damageDealt.Invoke();

        m_gameStateRef.TurnEnd();
    }

    public void SetAgility(float t_agility)
    {
        agility = t_agility;
    }

    public void Flee()
    {
        fleeAgility = m_gameStateRef.GetTargetAgility(State.ENEMY1);

        if (agility > fleeAgility)
        {
            SceneManager.LoadScene("Battle Entry");
        }
        else
        {
            fleeFail.Invoke();
        }
    }
}


