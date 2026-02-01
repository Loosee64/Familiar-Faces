using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenSwitch : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void BattleEntryScene()
    {
        SceneManager.LoadScene("Battle Entry");
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
