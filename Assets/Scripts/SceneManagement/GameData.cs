using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    private List<ScriptableObject> m_playerMasks;
    private GameObject m_currentEnemy;

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

    public List<ScriptableObject> GetPlayerMasks()
    {
        return m_playerMasks;
    }

    public CharacterData GetCurrentEnemyCharacter()
    {
        if( m_currentEnemy == null)
        {
            m_currentEnemy = new GameObject( "Enemy");
            m_currentEnemy.AddComponent<CharacterData>();
        }
        return m_currentEnemy.GetComponent<CharacterData>();
    }
}