using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial  class model_role
    {
        public model_role() { }

        private int _ID;
        private string _role_name;

        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public string role_name
        {
            set { _role_name = value; }
            get { return _role_name; }
        }
    }
}
