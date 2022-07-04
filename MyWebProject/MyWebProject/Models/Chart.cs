using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebProject.Models
{
    public class Chart
    {
        public String Gender { get; set; }
        public int Count { get; set; }
        public Chart(String Gender, int Count)
        {
            this.Gender = Gender;
            this.Count = Count;
        }
    }
}