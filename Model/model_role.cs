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
        private string _RoleName;

        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public string RoleName
        {
            set { _RoleName = value; }
            get { return _RoleName; }
        }

    }
}
