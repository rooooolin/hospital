using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class model_admin
    {
        public model_admin() { }

        private int _ID;
        private string _admin_name;
        private string _admin_password;
        private int _admin_roleid;


        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public string admin_name
        {
            set { _admin_name = value; }
            get { return _admin_name; }
        }
        public string admin_password
        {
            set { _admin_password = value; }
            get { return _admin_password; }
        }
        public int admin_roleid
        {
            set { _admin_roleid = value; }
            get { return _admin_roleid; }
        }
      
    }
}
