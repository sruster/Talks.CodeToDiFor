using System;
using System.Collections.Generic;
using System.Linq;

namespace Talks.SuperSpyLib.Imp
{
    public class FakeLogger : ILogger
    {
        private Stack<string> messages = new Stack<string>();
		public FakeLogger()
		{
			Console.Write(" -> FakeLogger Ctr");
		}

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