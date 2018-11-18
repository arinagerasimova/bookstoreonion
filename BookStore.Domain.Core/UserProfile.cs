using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Core
{
    public partial class UserProfile
    {
        public string Password { get; set; }
        
        public string UserName { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
