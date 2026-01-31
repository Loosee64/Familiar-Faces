using UnityEngine;

public class Mask : MonoBehaviour
{
    MaskType m_mask;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(m_mask.type);
    }
}
