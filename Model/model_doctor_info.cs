using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class model_doctor_info
    {
        public model_doctor_info()
        { }

        private int _ID;
        private string _doctor_name;
        private string _doctor_password;
        private string _doctor_education;
        private string _doctor_title;
        private string _doctor_telphone;
        private string _doctor_license;
        private string _doctor_phone;
        private string _doctor_email;
        private string _doctor_unit;
        private int _doctor_depart_id;
        private int _doctor_roleid;
        private int _doctor_state;
        private int _p_id;

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
        public string doctor_password
        {
            set { _doctor_password = value; }
            get { return _doctor_password; }

        }
        public string doctor_education
        {
            set { _doctor_education = value; }
            get { return _doctor_education; }
        }
        public string doctor_title
        {
            set { _doctor_title = value; }
            get { return _doctor_title; }
        }
        public string doctor_telphone
        {
            set { _doctor_telphone = value; }
            get { return _doctor_telphone; }
        }
        public string doctor_license
        {
            set { _doctor_license = value; }
            get { return _doctor_license; }
        }
        public string doctor_phone
        {
            set { _doctor_phone = value; }
            get { return _doctor_phone; }
        }
        public string doctor_email
        {
            set { _doctor_email = value; }
            get { return _doctor_email; }
        }
        public string doctor_unit
        {
            set { _doctor_unit = value; }
            get { return _doctor_unit; }
        }
        public int doctor_depart_id
        {
            set { _doctor_depart_id = value; }
            get{return _doctor_depart_id;}
        }
        public int doctor_roleid
        {
            set { _doctor_roleid = value; }
            get { return _doctor_roleid; }
        }
        public int doctor_state
        {
            set { _doctor_state = value; }
            get { return _doctor_state; }
        }
        public int p_id
        {
            set { _p_id = value; }
            get { return _p_id; }
        }
    }
}
