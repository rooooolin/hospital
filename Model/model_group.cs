using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class model_group
    {
        public model_group() { }
        private int _ID;
        private int _d_id;
        private string _group_name;
        private string _group_number;
        private string _p_id_list;
        private string _remarks;

        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public int d_id
        {
            set { _d_id = value; }
            get { return _d_id; }
        }
        public string group_name
        {
            set { _group_name = value; }
            get { return _group_name; }
        }
        public string group_number
        {
            set { _group_number = value; }
            get { return _group_number; }
        }
        public string p_id_list
        {
            set { _p_id_list = value; }
            get { return _p_id_list; }
        }
        public string remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
    }
}
