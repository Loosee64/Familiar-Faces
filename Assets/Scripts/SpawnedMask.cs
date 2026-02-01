using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SpawnedMask : MonoBehaviour
{
    [SerializeField]
    MaskType maskType;
    public UnityEvent selected;

    private void Awake()
    {
        selected.AddListener(() => GameData.Instance.AddMask(maskType));
    }

    public void SetType(MaskType type)
    {
        maskType = type;
        selected.Invoke();
    }

}
