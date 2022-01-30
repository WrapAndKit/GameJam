using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Additional
{
    public class CommandLibrary : ICommand
    {
        private LinkedList<ICommand> commands;

        public CommandLibrary()
        {
            commands = new LinkedList<ICommand>();
        }

        public void CommandAdd(ICommand command) => commands.AddLast(command);

        public void InputCheck()
        {
            foreach (var command in commands)
            {
                command.InputCheck();
            }
        }
    }
}
