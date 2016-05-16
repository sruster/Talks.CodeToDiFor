using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.PCL.SuperSpyLib.Imp
{
    public class FakeSpyLogger : ISpyLogger
    {
        private Stack<string> messages = new Stack<string>();


        public IEnumerable<string> GetMessages()
        {
            return messages;
        }
        public Stack<string> GetMessagesStack()
        {
            return messages;
        }

        public void Log(string Message)
        {
            messages.Push("Fake Log: " + Message);
        }
    }
}
