using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    bool m_canAct;

    public void StartTurn()
    {
        m_canAct = true;
    }

    public void EndTurn()
    {
        m_canAct = false;
    }

    public bool TurnCheck()
    {
        return m_canAct;
    }
}
