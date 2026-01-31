using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    private List<ScriptableObject> m_playerMasks;
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
    }


    public int playerHealth( int value = 0) 
    {
        m_playerHealth -= value;

        return m_playerHealth;
        
    }
    public List<ScriptableObject> GetPlayerMasks()
    {
        return m_playerMasks;
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