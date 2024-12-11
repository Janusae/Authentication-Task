using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnection.TableEntitiy
{
	public class User : Base
	{
        public string fullName { get; set; }
        public string  userName{ get; set; }
        public string  Email{ get; set; }
        public string  passWord{ get; set; }
        public userLevel userRole { get; set; }
    }
    public enum userLevel
    {
        Admin ,
        Author , 
        Standard
    }
}
