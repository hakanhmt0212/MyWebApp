using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebProject.Models
{
    public class ViewModel
    {
        [Key]
        public int ID { get; set; }
        public IEnumerable<Person> Person { get; set; }
        public IEnumerable<Cities> Cities { get; set; }
    }
}