using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SpawnedMask : MonoBehaviour
{
    MaskType maskType;
    bool spawned;
    UnityEvent selected;
    int indexSelected;

    [SerializeField]
    RectTransform panelRef;

    private void Awake()
    {
        selected.AddListener(() => GameObject.FindGameObjectWithTag("Player").GetComponent<PartyMember>().AddMask(maskType, indexSelected));
        indexSelected = 0;
    }
    private void Update()
    {
        if (spawned)
        {
            panelRef.gameObject.SetActive(true);
        }
    }

    public bool IsSpawned()
    {
        return spawned;
    }

    public void SetType(MaskType type)
    {
        maskType = type;
        spawned = true;
    }

    public void SelectMask()
    {
        selected.Invoke(); ;
        spawned = false;
    }

}
