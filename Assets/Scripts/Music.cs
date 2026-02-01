using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
        void Awake()
        {
            GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
            if (musicObj.Length > 1)
            {
                Destroy(this.gameObject);
            }
            DontDestroyOnLoad(this.gameObject);
        }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
