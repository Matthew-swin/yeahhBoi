using System;
using System.Collections.Generic;

namespace models
{
    public class Movie
    {
        public int movieNo { get; set; }
        public string title { get; set; }
        public Int16 relYear { get; set; }
        public Int16 runTime { get; set; }
        
        //use dis in controller
        public DateTime currentDateTime = DateTime.Now;

        public int NumActors(string movieName){
            return 1;
        }
    }
}