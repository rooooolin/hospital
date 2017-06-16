using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class get_control
    {
        private string _ID;
        private string _control_name;
        private string _control_type;
        private string _control_value;
        public get_control(model_control model)
        {
            this._ID = model.ID;
            this._control_name = model.control_name;
            this._control_type = model.control_type;
            this._control_value = model.control_value;
        }
        public string ID
        {
            
            get { return _ID; }
        }
        public string control_name
        {
           
            get { return _control_name; }
        }
        public string control_type
        {
            
            get { return _control_type; }
        }

        public string control_value
        {
            
            get { return _control_value; }
        }


    }
}
