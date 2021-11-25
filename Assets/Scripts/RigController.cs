using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using DG.Tweening;

namespace Assets.Scripts
{
    [Serializable]
    public class RigController
    {
        public Transform TargetTransform;

        [SerializeField] private Rig _rig;

        public void SetRigValue(float value, float defaultRigSpeed = 0.5f, Action callback = null)
        {
            DOTween.To(() => _rig.weight, x => _rig.weight = x, value, defaultRigSpeed).OnComplete(() => callback?.Invoke());
        }
    }
}
