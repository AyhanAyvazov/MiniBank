using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBank.Domain.Entities.Customers
{
    public class Customers : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }  
        public long PersonalNumber { get; set; }
        public long MobileNumber { get; set; }
    }
}
