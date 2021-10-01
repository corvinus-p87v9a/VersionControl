using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.het.Entities
{
    public class user
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
 
        
    }
}