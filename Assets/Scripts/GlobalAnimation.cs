using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class GlobalAnimation : MonoBehaviour
    {
        [SerializeField] private Door _door;
        [SerializeField] private Cannon _cannon;
        [SerializeField] private Character _character;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                StartSequence();
            }
        }

        private void StartSequence()
        {
            _character.PlaceHand(_door.HandPlace.position, () =>
            {
                _door.Open(() =>
                {
                    _character.HandOff(()=> 
                    {
                        _character.DodgeBullet(()=>
                        {
                            _character.SpineOff();
                            _door.Close();
                        });
                        _cannon.Shoot();
                    });
                    
                });
            });
        }
    }
}
