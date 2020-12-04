using System;
using System.Collections.Generic;

namespace models
{
    public class Actor
    {
        public int actorNo { get; set; }
        public string fullName { get; set; }
        public string givenName { get; set; }
        public string surname { get; set; }
        

        public void setFullName() {
            this.fullName = givenName + " " + surname;
        }
    }
}
