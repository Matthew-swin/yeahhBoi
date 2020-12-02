using System;
using System.Collections.Generic;

namespace models
{
    public class Actor
    {
        public int actorNo { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }

        public void setFullName() {
            this.fullName = firstName + " " + lastName;
        }
    }
}
