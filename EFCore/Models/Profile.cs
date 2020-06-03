using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public partial class Profile
    {
        public int Id { get; set; }
        public string EMail { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
