using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Additional
{
    public abstract class ACommand: ICommand
    {
        protected internal KeyCode key;

        protected internal abstract void Execute();

        public ACommand(KeyCode _key)
        {
            key = _key;
        }

        public void InputCheck()
        {
            if (Input.GetKey(key))
            {
                Execute();
            }   
        }

    }
}
