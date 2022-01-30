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

        private CommandLibrary commandLibrary;

        private void Start()
        {
            //commandLibrary = new CommandLibrary();
            //commandLibrary.CommandAdd(new MoveObjectCommand(gameObject));
            strategy = new SkeletonMovementStrategy(gameObject);
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            base.FixedUpdate();
            //commandLibrary.InputCheck();
        }

        public override void ChangeState()
        {
            if (state is ControlledState)
            {
                state = new LazyState();
                ChangeStrategy(new SkeletonLazyStrategy());
                tag = "EnemyUnit";
                gameObject.GetComponent<Animator>().Play("DeathSkeleton");
            }
            else
            {
                if (state is LazyState)
                {
                    gameObject.GetComponent<Animator>().Play("AliveSkeleton");
                    gameObject.GetComponent<Animator>().Play("IdleDownSkeleton");

                }   
                tag = "Player";
                state = new ControlledState();
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().playerObject = gameObject;
            }
        }
    }
}
