using System.Collections.Generic;
using KeyInventory;
using UnityEngine;

public class GameEndDoorManager : MonoBehaviour
{
    [SerializeField] private KeyInventorySO keyInventory;
    [SerializeField] private List<GameObject> doors;
    private void Start()
    {
        keyInventory.LoadKeys();
        InitDoors();
    }

    private void InitDoors()
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            doors.Add(transform.GetChild(i).gameObject);
        }

        for (var i = 0; i < keyInventory.GetStoryKeyCount(); i++)
        {
            doors[i].SetActive(false);
        }
    }
}
