using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class model_patient_group
    {
        public model_patient_group()
        {}
        private int _ID;
        private int _group_number;
        private string _gropu_name;

        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public int group_number
        {
            set { _group_number = value; }
            get { return _group_number; }
        }
        public string group_name
        {
            set { _gropu_name = value; }
            get { return _gropu_name; }
        }
    }
}
