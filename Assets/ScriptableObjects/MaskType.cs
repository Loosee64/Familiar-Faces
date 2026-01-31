using UnityEngine;

[CreateAssetMenu(fileName = "MaskType", menuName = "Scriptable Objects/MaskType")]
public class MaskType : ScriptableObject
{
    public string type = "";
    public float damageMult = 1.0f;
    public float costMult = 1.0f;
}
