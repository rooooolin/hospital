using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class model_user
    {
        public model_user() { }

        private int _ID;
        private string _user_password;
        private string _user_name;
        private string _user_ID_Card;
        private string _user_patient_number;
        private string _user_phone;
        private string _user_sex;
        private string _user_birthday;
        private string _user_work_address;
        private Boolean _user_is_married;
        private string _user_contact;
        private string _user_contact_rela;
        private string _user_contact_phone;
        private int _user_roleid;
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public string user_password
        {
            set { _user_password = value; }
            get{return _user_password;}
        }
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        public string user_ID_Card 
        {
            set { _user_ID_Card = value; }
            get { return _user_ID_Card; }
        }
        public string ser_patient_number
        {
            set { _user_patient_number = value; }
            get { return _user_patient_number; }
        }
        public string user_phone
        {
            set { _user_phone = value; }
            get { return _user_phone; }
        }
        public string user_sex
        {
            set { _user_sex = value; }
            get { return _user_sex; }
        }
        public string user_birthday 
        {
            set { _user_birthday = value; }
            get { return _user_birthday; }
        }
        public string user_work_address 
        {
            set { _user_work_address = value; }
            get { return _user_work_address; }
        }
        public Boolean user_is_married
        {
            set { _user_is_married = value; }
            get { return _user_is_married; }
        }
        public string user_contact 
        {
            set { _user_contact = value; }
            get { return _user_contact; }
        }
        public string user_contact_rela 
        {
            set { _user_contact_rela = value; }
            get { return _user_contact_rela; }
        }
        public string user_contact_phone
        {
            set { _user_contact_phone = value; }
            get { return _user_contact_phone; }
        }
        public int user_roleid
        {
            set { _user_roleid = value; }
            get { return _user_roleid; }
        }
    }
}
