using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yape.Api.Core.Models
{
    public class Client
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CellPhoneNumber { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
    }
}
