using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationModule.Model
{
    public class RegisterApp
    {
        public DateTime CreateDate { get; set; }
        public int Number { get; set; }
        public string OrganizationName { get; set; }
        public string UserFullName { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
    }

}
