using UnityEngine;

[CreateAssetMenu(fileName = "CharacterType", menuName = "Scriptable Objects/CharacterType")]
public class CharacterType : ScriptableObject
{
    public string title = "";
    public int maxHealth = 0;
    public int xp = 0;
    public MaskType mask;
}
