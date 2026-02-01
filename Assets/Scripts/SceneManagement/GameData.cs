using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    [SerializeField]
    private MaskType[] m_emptyMasks;
    [SerializeField]
    private MaskType[] m_playerMasks;
    int maskIndex;
    private string m_currentEnemy;
    private int m_playerHealth;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        ResetMasks();
    }

    public void ResetMasks()
    {
        m_playerMasks[0] = m_emptyMasks[0];
        m_playerMasks[1] = m_emptyMasks[1];
        m_playerMasks[2] = m_emptyMasks[2];
        maskIndex = 0;
    }

    public int playerHealth( int value = 0) 
    {
        m_playerHealth -= value;

        return m_playerHealth;
        
    }
    public MaskType[] GetPlayerMasks()
    {
        return m_playerMasks;
    }

    public void setPlayerMasks(MaskType[] t_masks)
    {
        m_playerMasks = t_masks;
    }

    public void AddMask(MaskType mask)
    {
        if (maskIndex < 3)
        {
            m_playerMasks[maskIndex] = mask;
            maskIndex++;
        }
    }

    public void setCurrentEnemyCharacterName(string t_name)
    {
        m_currentEnemy = t_name; 
    }
    public string GetCurrentEnemyCharacterName()
    {

        return m_currentEnemy;
    }
}