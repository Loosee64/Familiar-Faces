using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmtrySceneManager : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI m_entryText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        if (GameData.Instance != null)
        {
            CharacterData m_currentEnemy = GameData.Instance.GetCurrentEnemyCharacter();
            m_currentEnemy.GetComponent<CharacterData>().NewRandom();
            Debug.Log(m_currentEnemy.GetTitle());
        }
        else
        {
            Debug.Log("singleton is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CharacterData m_currentEnemy = GameData.Instance.GetCurrentEnemyCharacter();
        GameData.Instance.GetCurrentEnemyCharacter();

        m_entryText.text = "You will be fighting " + m_currentEnemy.GetTitle() + ", Good luck!!!";
      
    }

    public void beginFight()
    {
        SceneManager.LoadScene("Battle");
    }
}
