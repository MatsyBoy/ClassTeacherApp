using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassTeacher_App.Managers
{
    public  class TeachersManager
    {

        public   List<Class> _getAllTeacherClasses(int _teacherID)
        {
            List<Class> classes = new List<Class>();
            string query=string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);
               
                conn.Open();

                query = "select * from vw_ClassesPerTeacher where teacherID=@teacherID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@teacherID", _teacherID);

                MySqlDataReader dataReader = cmd.ExecuteReader();
                                
                while (dataReader.Read())
                {

                    Class _class=new Class();
                    _class.className =Convert.ToString( dataReader["className"]);
                    _class.classID = Convert.ToInt32(dataReader["classID"]);
                    _class.yearOfCreation = Convert.ToInt32(dataReader["yearOfCreation"]);

                    classes.Add(_class);
                }

                //close Data Reader
                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return classes;
        }

    }
}