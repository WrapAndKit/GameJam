using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Additional
{
    /*
    public class MoveObjectCommand: ACommand
    {
        private GameObject owner;
        public MoveObjectCommand(GameObject _owner) : base(KeyCode.Space)
        {
            owner = _owner;
        }
        
        protected internal override void Execute()
        {
            if (owner.GetComponent<Collider2D>().IsTouchingLayers(LayerMask.GetMask("Movable")))
            {
                Rigidbody2D rb = owner.GetComponent<Collider2D>().GetComponent<Collision2D>()?.gameObject.GetComponent<Rigidbody2D>();
                rb.MovePosition(
                    rb.position + 
                    new Vector2 (Input.GetAxis("Horizontal"), 0)
                    );
            }
        }
    }
    
    public class TakeObjectCommand : ACommand
    {
        private GameObject owner;
        private GameObject aim;

        public TakeObjectCommand(GameObject _owner, GameObject _aim) : base(KeyCode.Z)
        {
            owner = _owner;
            aim = _aim;
        }

        public void SetAim(GameObject _aim)
        {
            aim = _aim;
        }

        protected internal override void Execute()
        {
            if (aim != null)
            {
                aim.transform.parent = owner.transform;
                aim.GetComponent<Rigidbody2D>().MovePosition(owner.GetComponent<Rigidbody2D>().position);
            }
        }
    }
    */
}
