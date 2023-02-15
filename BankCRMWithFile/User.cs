using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCRMWithFile
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Appeal { get; set; }
        public DateTime RegisteredData { get; set; } = DateTime.Now;
    }
}
