using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Банкомат
{
    internal class Person
    {
        [Key]
        public string CardNumber { get; set; }  
        public string? PinCode {  get; set; }
        public string? FirstName { get; set; }   
        public string? LastName { get; set; }
        public int BirthYear { get; set; }
        public int Money { get; set;}
    }
}
