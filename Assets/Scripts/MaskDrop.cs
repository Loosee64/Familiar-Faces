using UnityEngine;

public class MaskDrop : MonoBehaviour
{
    CharacterData characterData;
    MaskType m_mask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterData = GetComponent<CharacterData>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (m_mask == null)
        {
            m_mask = characterData.GetMask();
        }
    }

    public MaskType Drop()
    {
        return m_mask;
    }
}
