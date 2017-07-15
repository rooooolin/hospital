using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class model_pushlog
    {
        public model_pushlog() { }
        private int _ID;
        private string _activator;
        private string _target;
        private string _push_time;
        private string _result;
        private string _remarks;

        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        public string activator
        {
            set { _activator = value; }
            get { return _activator; }
        }
        public string target
        {
            set { _target = value; }
            get { return _target; }
        }
        public string push_time
        {
            set { _push_time = value; }
            get { return _push_time; }
        }
        public string result
        {
            set { _result = value; }
            get { return _result; }
        }
        public string remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
    }
}
