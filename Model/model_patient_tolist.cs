using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class model_patient_tolist
    {
        public model_patient_tolist()
        { }
        private int _ID;
        private string _user_name;
        private string _user_patient_number;
        private string _user_phone;

        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
      
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
       
        public string user_patient_number
        {
            set { _user_patient_number = value; }
            get { return _user_patient_number; }
        }
        public string user_phone
        {
            set { _user_phone = value; }
            get { return _user_phone; }
        }
       
    }
}
