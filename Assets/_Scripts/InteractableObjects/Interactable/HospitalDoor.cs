using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Game.Interafaces;
using UnityEngine;

public class HospitalDoor : MonoBehaviour, IInteractable
{
    public void Execute()
    {
        transform.DOLocalRotate(transform.localRotation.z != 0 ? new Vector3(-90, 0, 0) : new Vector3(-90, 0, 90), 1f);
    }
}
