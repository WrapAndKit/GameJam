using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Additional
{
    public interface IStrategy
    {
        public void Execute(float deltaTime);
    }
}
