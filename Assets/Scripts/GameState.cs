using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public enum State
{
    PLAYER1,
    ENEMY1,
    END
}

public class GameState : MonoBehaviour
{
    [SerializeField]
    private TurnSystem[] m_entities;

    [SerializeField]
    Button m_buttonAttack;
    [SerializeField]
    Button m_buttonMask;

    public UnityEvent playerTurn;
    public UnityEvent battleEnd;

    State current;

    private void Start()
    {
        playerTurn.AddListener(GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Dialogue>().PlayerTurn);
        BattleStart();
    }

    public State getTurn()
    {
        return current;
    }

    public void BattleStart()
    {
        current = State.PLAYER1;
        m_entities[(int)current].StartTurn();
    }

    public Health GetTarget(State t_target)
    {
        switch (t_target)
        {
            case State.PLAYER1:
                return m_entities[(int)State.PLAYER1].GetComponent<Health>();
            case State.ENEMY1:
                return m_entities[(int)State.ENEMY1].GetComponent<Health>();
            default:
                break;
        }
        return m_entities[(int)State.ENEMY1].GetComponent<Health>();
    }

    public string GetTargetName(State t_target)
    {
        switch (t_target)
        {
            case State.PLAYER1:
                return m_entities[(int)State.PLAYER1].GetComponent<CharacterData>().GetTitle();
            case State.ENEMY1:
                return m_entities[(int)State.ENEMY1].GetComponent<CharacterData>().GetTitle();
            default:
                break;
        }
        return m_entities[(int)State.ENEMY1].GetComponent<CharacterData>().GetTitle();
    }

    public float GetTargetAgility(State t_target)
    {
        switch(t_target)
        {
            case State.PLAYER1:
                return m_entities[(int)State.PLAYER1].GetComponent<CharacterData>().GetAgility();
            case State.ENEMY1:
                return m_entities[(int)State.ENEMY1].GetComponent<CharacterData>().GetAgility();
            default:
                break;
        }
        return m_entities[(int)State.ENEMY1].GetComponent<CharacterData>().GetAgility();
    }

    public float GetTargetDefense(State t_target)
    {
        switch (t_target)
        {
            case State.PLAYER1:
                return m_entities[(int)State.PLAYER1].GetComponent<CharacterData>().GetDefense();
            case State.ENEMY1:
                return m_entities[(int)State.ENEMY1].GetComponent<CharacterData>().GetDefense();
            default:
                break;
        }
        return m_entities[(int)State.ENEMY1].GetComponent<CharacterData>().GetDefense();
    }

    public void Flee()
    {
        battleEnd.Invoke();
    }

    public void TurnEnd()
    {
        m_entities[(int)current].EndTurn();

        if (current < State.END)
        {
            current++;
        }
        if (current == State.END)
        {
            current = State.PLAYER1;
        }

        StartCoroutine(StartTurn());
    }

    public void ForcePlayerTurn()
    {
        current = State.PLAYER1;

        StartCoroutine(StartTurn());
    }

    IEnumerator StartTurn()
    {
        yield return new WaitForSeconds(1.0f);
        m_entities[(int)current].StartTurn();

        if (current < State.ENEMY1)
        {
            playerTurn.Invoke();
            m_buttonAttack.gameObject.SetActive(true);
            m_buttonMask.gameObject.SetActive(true);
        }
    }
}
