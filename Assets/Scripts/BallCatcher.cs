using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BallCatcher : MonoBehaviour
{
    [SerializeField] private Rigidbody _ballRb;

    [SerializeField] private float _minBallY;

    [SerializeField] private float _force;

    [SerializeField] private float _scatter;

    [SerializeField] private Rig _handRig;

    [SerializeField] private Transform _handRigTarget;

    private Transform _ballTransform;
    private float _ballXStartPosition;

    private void Awake()
    {
        _ballTransform = _ballRb.transform;
        _ballXStartPosition = _ballTransform.position.x;
    }

    private void Update()
    {
        _handRigTarget.position = _ballTransform.position;

        if(_ballTransform.position.y < _minBallY && Time.time > _timer)
        {
            PushBall();
        }
    }

    private float _timer;
    private void PushBall(float defaultRigSpeed = 0.2f)
    {
        _timer = Time.time + 0.5f;

        DOTween.To(() => _handRig.weight, x => _handRig.weight = x, 1, defaultRigSpeed).OnComplete(()=>
        {
            DOTween.To(() => _handRig.weight, x => _handRig.weight = x, 0, defaultRigSpeed);
        });

        _ballRb.velocity = Vector3.zero;

        float rngX = 0;
        if (_ballTransform.position.x > _ballXStartPosition + 0.3)
        {
            rngX = UnityEngine.Random.Range(-_scatter,0);
        }
        else if(_ballTransform.position.x < _ballXStartPosition -0.3)
        {
            rngX = UnityEngine.Random.Range(0, _scatter);
        }
        else
        {
            rngX = UnityEngine.Random.Range(-_scatter, _scatter);
        }

        _ballRb.AddForce(new Vector3(rngX, _force, 0), ForceMode.Force);
    }
}
