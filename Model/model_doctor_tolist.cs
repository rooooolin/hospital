using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class model_doctor_tolist
    {
        public model_doctor_tolist()
        { }

        private int _ID;
        private string _doctor_name;
        private string _doctor_title;
        private string _doctor_unit;

        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public string doctor_name
        {
            set { _doctor_name = value; }
            get { return _doctor_name; }
        }
       
      
        public string doctor_title
        {
            set { _doctor_title = value; }
            get { return _doctor_title; }
        }
      
      
        public string doctor_unit
        {
            set { _doctor_unit = value; }
            get { return _doctor_unit; }
        }
       
    }
}
