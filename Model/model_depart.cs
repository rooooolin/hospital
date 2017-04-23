using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class model_depart
    {
        public model_depart()
        { }
        private int _ID;
        private string _depart_number;
        private string _depart_name;

        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public string depart_number
        {
            set { _depart_number = value; }
            get { return _depart_number; }
        }
        public string depart_name
        {
            set { _depart_name = value; }
            get { return _depart_name; }
        }
    }
}
