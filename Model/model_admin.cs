using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public partial class model_admin
    {
        public model_admin() { }

        private int _ID;
        private string _UserName;
        private string _PassWd;
        private int _RoleID;
        private DateTime _CreatDate=DateTime.Now;


        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public string UserName
        {
            set { _UserName = value; }
            get { return _UserName; }
        }
        public string PassWd
        {
            set { _PassWd = value; }
            get { return _PassWd; }
        }
        public int RoleID
        {
            set { _RoleID = value; }
            get { return _RoleID; }
        }
        public DateTime CreatDate
        {
            set { _CreatDate = value; }
            get { return _CreatDate; }
        }
    }
}
