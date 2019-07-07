using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassTeacher_App
{
    public class DBConnection
    {
        private const string c_server = "mytest1.cvvbdt0dipxo.us-east-1.rds.amazonaws.com";
        private const int c_port = 3306;
        private const string c_db = "myFirstDatabase";
        private const string c_userID = "mats";
        private const string c_pwd = "mats4321";

        private string pwd;

        public string connectionString { get; set; }

        private MySqlConnection myConnection;
        public string server { get; set; }

        public string userID { get; set; }
        public int port { get; set; }
        public string db { get; set; }


        public string _pwd
        {
            get { return pwd; }

            set
            {
                if (string.IsNullOrEmpty(value)) { throw new Exception("Password must have a value."); }
                pwd = value;
            }
        }

        //public string _connectionString
        //{
        //    set
        //    {
        //        if (string.IsNullOrEmpty(value)) { throw new Exception("ConnectionString must not be empty."); }
        //        connectionString = value;
        //    }

        //}

        public MySqlConnection _myConnection
        {
            set
            {
                myConnection = value;
            }

            get
            { return this.myConnection; }

        }


        public DBConnection(string _server, string _db, int _port, string _userName, string __pwd)
        {
            server = _server;
            db = _db;
            port = _port;
            userID = _userName;
            _pwd = __pwd;

            connectionString = "SERVER=" + this.server + ";" + "DATABASE=" +
        this.db + ";" + "UID=" + this.userID + ";" + "PASSWORD=" + this.pwd + ";";

            _myConnection = new MySqlConnection(this.connectionString);

        }

        public DBConnection()
        {
            server = c_server;
            db = c_db;
            port = c_port;
            userID = c_userID;
            _pwd = c_pwd;

            connectionString = "SERVER=" + this.server + ";" + "DATABASE=" +
        this.db + ";" + "UID=" + this.userID + ";" + "PASSWORD=" + this.pwd + ";";

            _myConnection = new MySqlConnection(this.connectionString);

        }
    }
}