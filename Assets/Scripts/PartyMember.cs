using UnityEngine;

public class PartyMember : MonoBehaviour
{
    [SerializeField]
    private int m_maxSP;
    [SerializeField]
    private ActionType[] m_actions;
    [SerializeField]
    MaskType[] m_masks;
    int m_currentMaskIndex;

    MaskType m_equippedMask;

    Action m_action;
    TurnSystem m_turn;
    Health m_health;
    CharacterData m_character;

    float m_xp;
    int m_level;
    int m_sp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_sp = m_maxSP;
        m_action = GetComponent<Action>();
        m_turn = GetComponent<TurnSystem>();
        m_health = GetComponent<Health>();
        m_character = GetComponent<CharacterData>();

        m_health.setMax(m_character.GetMax());
    }

    // Update is called once per frame
    void Update()
    {
    }

    public string Name()
    {
        return m_character.GetTitle();
    }

    public void AddXP(float t_amount)
    {
        m_xp += t_amount;
        if (m_xp >= 10)
        {
            LevelUp((int)m_xp / 10);
        }
    }

    private void LevelUp(int t_amount)
    {
        m_level += t_amount;
        m_character.IncreaseMax(m_level);
        m_health.setMax(m_character.GetMax());
    }

    public void Attack(int t_type)
    {
        if (m_turn.TurnCheck())
        {
            m_action.Execute(State.ENEMY1, m_actions[t_type]);
        }
    }

    public void AddMask(MaskType type, int index)
    {
        if (m_masks.Length < 3)
        {
            m_masks[index] = type;
        }
    }

    public void ChangeMask(int index, MaskType type)
    {
        m_equippedMask = m_masks[index];
    }
}
