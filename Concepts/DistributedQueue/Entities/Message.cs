using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributedQueue.Entities
{
    public class Message
    {
        public string Text { get; private set; }

        public Message(string text)
        {
            Text = text;
        }

    }
}
