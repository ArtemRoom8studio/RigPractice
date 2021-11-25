using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private Transform _bullet;

    private Vector3 _bulletStartPos;

    public void Shoot(Action callback = null)
    {
        _bulletStartPos = _bullet.position;
        _bullet.DOMoveZ(-10, 1f).OnComplete(() => 
        {
            _bullet.position = _bulletStartPos;
            callback?.Invoke();
        });
    }    
}
