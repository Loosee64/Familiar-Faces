using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{

    [SerializeField]  private ActionType m_type;
    [SerializeField] TextMeshProUGUI m_nameText;

    Action m_action;
    TurnSystem m_turn;
    Health m_health;
    CharacterData m_character;
    
    public UnityEvent m_deadEvent;
    bool m_respawned = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_action = GetComponent<Action>();
        m_turn = GetComponent<TurnSystem>();
        m_health = GetComponent<Health>();
        m_character = GetComponent<CharacterData>();

        if (GameData.Instance != null )
        {
            Debug.Log(GameData.Instance.GetCurrentEnemyCharacterName());

            m_character.loadCharaacter( GameData.Instance.GetCurrentEnemyCharacterName() ); 
        }
        m_nameText.text = m_character.GetTitle();
        m_health.setMax(m_character.GetMax());

        m_deadEvent.AddListener(() => GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Dialogue>().DisplayDeath(m_character.GetTitle()));
        m_deadEvent.AddListener(() => GameObject.FindGameObjectWithTag("Player").GetComponent<PartyMember>().AddXP(m_character.GetXP()));
        m_deadEvent.AddListener(() => GameObject.FindGameObjectWithTag("SpawnedMask").GetComponent<SpawnedMask>().SetType(m_character.GetMask()));
    }

    // Update is called once per frame
    void Update()
    {
        if (m_turn.TurnCheck() && m_health.IsAlive())
        {
            m_action.Execute(State.PLAYER1, m_type.m_damage * m_character.GetAttack(), m_type.m_cost);
        }
        else if (!m_health.IsAlive() && !m_respawned)
        {
            m_deadEvent.Invoke();
            m_respawned = true;
            SceneManager.LoadScene("Win");
        }
       

    }
}
