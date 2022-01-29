using Assets.Scripts.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;

namespace Assets.Scripts
{
    class Bat: AControllableNPC
    {

        private void Start()
        {
            strategy = new BatMovementStrategy(gameObject);
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public override void ChangeState()
        {
            if (state is ControlledState)
            {
                state = new NormalState();
                tag = "EnemyUnit";
            }
            else
            {
                tag = "Player";
                state = new ControlledState();
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().playerObject = gameObject;
            }
        }
    }
}
