using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Additional
{
    public abstract class AControllableNPC: MonoBehaviour, IControllable
    {
        private Vector2 movement;


        protected internal IState state = new NormalState();
        protected internal IStrategy strategy;
        protected internal Rigidbody2D rigidbody;
        protected internal GameObject invader;

        public float speed;
        public float timeToInvader = 1f;
        public abstract void ChangeState();

        public void ChangeStrategy(IStrategy _strategy) => strategy = _strategy;

        public void SetInvader(GameObject _invader) => invader = _invader;

        protected internal virtual void Update()
        {
            if (state is ControlledState)
            {
                Vector2 moveInput = new Vector2(
                            Input.GetAxisRaw("Horizontal"),
                            Input.GetAxisRaw("Vertical"));
                movement = moveInput.normalized * speed;
            }
        }

        protected internal virtual void FixedUpdate()
        {
            if (state is ControlledState)
            {
                rigidbody.MovePosition(rigidbody.position + movement * Time.fixedDeltaTime);
                if (Input.GetKey(KeyCode.X))
                {
                    ChangeState();
                    InvaderActivation();
                }
            }
            else
            {
                strategy.Execute(Time.fixedDeltaTime);
            }
        }

        private void InvaderActivation()
        {   
            invader.GetComponent<Rigidbody2D>().MovePosition(gameObject.GetComponent<Rigidbody2D>().position - new Vector2(8f, 8f));
            invader.SetActive(true);
            invader.GetComponent<PlayerController>().Show();
        }
    }
}
