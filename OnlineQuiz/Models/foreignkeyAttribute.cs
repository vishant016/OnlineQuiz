using System;

namespace Online_Quiz.Models
{
    internal class foreignkeyAttribute : Attribute
    {
        private string v;

        public foreignkeyAttribute(string v)
        {
            this.v = v;
        }
    }
}