using System;
using System.Collections.Generic;

namespace models
{
    public class Movie
    {
        public int movieNo { get; set; }
        public string title { get; set; }
        public int relYear { get; set; }
        public int runTime { get; set; }
        
        //use dis in controller
        public DateTime currentDateTime = DateTime.Now;

        public int NumActors(string movieName){
            return 1;
        }
    }
}