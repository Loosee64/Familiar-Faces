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

            GameObject go = new GameObject("character");
            CharacterData character = go.AddComponent<CharacterData>();
            character.NewRandom();

            GameData.Instance.setCurrentEnemyCharacterName(character.GetTitle());
         
        }
        else
        {
            Debug.Log("singleton is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
     
      if(GameData.Instance != null)
      {
         m_entryText.text = "You will be fighting " + GameData.Instance.GetCurrentEnemyCharacterName() + ", Good luck!!!";
      }
        
      
    }

    public void beginFight()
    {
        SceneManager.LoadScene("Battle");
    }
}
