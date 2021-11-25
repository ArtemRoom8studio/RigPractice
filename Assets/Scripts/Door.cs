using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform HandPlace;

    [SerializeField] private Transform _door;

    public void Open(Action callback = null)
    {
        _door.DORotate(new Vector3(0, -90, 0), 0.5f).OnComplete(()=> callback?.Invoke());
    }

    public void Close()
    {
        _door.DORotate(Vector3.zero, 0.5f);
    }
}
