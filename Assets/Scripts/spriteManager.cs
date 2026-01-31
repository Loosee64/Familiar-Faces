using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spriteManager : MonoBehaviour
{
    public  SpriteRenderer spriteRenderer;
    public List<Sprite> sprites = new List<Sprite>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        string name = GameData.Instance.GetCurrentEnemyCharacterName();
        if (name == "Crow")
        {
            spriteRenderer.sprite = sprites[2];
            spriteRenderer.transform.localScale = new Vector3(0.7f, 0.7f, 1.0f);
        }
        else if (name == "Squirrel")
        {
            spriteRenderer.sprite = sprites[1];
            spriteRenderer.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else if (name == "Fox")
        {
            spriteRenderer.sprite = sprites[0];
            spriteRenderer.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }
}
