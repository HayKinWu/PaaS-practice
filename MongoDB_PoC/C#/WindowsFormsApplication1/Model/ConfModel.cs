using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.Model
{
    public class ConfModel
    {
        //public const string mongodb_ConnFormat = "mongodb://devuser:Foxconn123@10.132.36.118:27017/TestDB";//mongodb://username:password@myserver:port/databaseName
        public string mongodb_ConnFormat
        {
            get;
            set;
        }

        public string mongodb_dbAddr
        {
            get;
            set;
        }
        public string mongodb_dbName
        {
            get;
            set;
        }
        public string mongodb_uName
        {
            get;
            set;
        }
        public string mongodb_uPwd
        {
            get;
            set;
        }
        public int mongodb_port
        {
            get;
            set;
        }


        public int mongodb_Pool
        {
            get;
            set;
        }

        public int mongodb_minPool
        {
            get;
            set;
        }

        public string mongodb_conn
        {
            get
            {
                return string.Format(mongodb_ConnFormat, mongodb_uName, mongodb_uPwd, mongodb_dbAddr, mongodb_port, mongodb_dbName);
            }
        }

        public string folder
        {
            get;
            set;
        }
    }
}
