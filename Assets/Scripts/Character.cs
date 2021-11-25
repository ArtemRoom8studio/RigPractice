using Assets.Scripts;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private RigController _hand;

    [SerializeField] private RigController _spine;

    public void PlaceHand(Vector3 position, Action callback = null)
    {
        _hand.TargetTransform.position = position;

        _hand.SetRigValue(1, callback: callback);
    }

    public void DodgeBullet(Action callback = null)
    {
        _spine.SetRigValue(1, defaultRigSpeed: 0);
        _spine.TargetTransform.DORotate(new Vector3(-37, 58, 0), 0.5f).OnComplete(() => callback?.Invoke());
    }

    public void HandOff(Action callback = null)
    {
        _hand.SetRigValue(0,callback: callback);
    }

    public void SpineOff(Action callback = null)
    {
        _spine.SetRigValue(0, callback: ()=> 
        {
            _spine.TargetTransform.rotation = Quaternion.Euler(Vector3.zero);        
            callback.Invoke();
        });
    }
}
