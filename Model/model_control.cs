using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class model_control
    {

        public model_control()
        {

        }
        private string _ID;
        private string _control_name;
        private string _control_type;
        private string _control_value;
        
        public string ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public string control_name
        {
            set { _control_name = value; }
            get { return _control_name; }
        }
        public string control_type
        {
            set { _control_type = value; }
            get { return _control_type; }
        }

        public string control_value
        {
            set { _control_value = value; }
            get { return _control_value; }
        }



    }
}
