using Assets.Scripts.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Skeleton : AControllableNPC
    {

        private void Start()
        {
            strategy = new SkeletonMovementStrategy(gameObject);
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public override void ChangeState()
        {
            if (state is ControlledState)
            {
                state = new LazyState();
                ChangeStrategy(new SkeletonLazyStrategy());
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
