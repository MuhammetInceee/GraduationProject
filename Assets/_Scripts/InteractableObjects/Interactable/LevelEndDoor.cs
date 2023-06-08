using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game.Interafaces;
using UnityEngine;

public class LevelEndDoor : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject leftDoor;
    [SerializeField] private GameObject rightDoor;
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
    }

    public void Execute()
    {
        leftDoor.transform.DOLocalRotate(new Vector3(0, -90, 0), 1);
        rightDoor.transform.DOLocalRotate(new Vector3(0, 270, 0), 1);
        _collider.enabled = false;
    }
}
