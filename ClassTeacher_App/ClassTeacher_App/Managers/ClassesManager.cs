using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassTeacher_App.Managers
{
    public class ClassesManager
    {

       public bool _addNewClass(Class _Class)
        {
            bool done = true;

            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "insert into tbClasses ( className, yearOfCreation) values ( @className, @yearOfCreation)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
               
                cmd.Parameters.AddWithValue("@className", _Class.className );
                cmd.Parameters.AddWithValue("@yearOfCreatio", _Class.yearOfCreation);

                int result = cmd.ExecuteNonQuery();

                done = result > 0;
                           
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return done;
        }

        public bool _addClassToTeacherClasses(int classID,int teacherID)
        {
            bool done = true;

            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "insert into tbClassesPerTeacher ( classID, teacherID) values ( @classID, @teacherID)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                
                cmd.Parameters.AddWithValue("@classID", classID);
                cmd.Parameters.AddWithValue("@teacherID", teacherID);

                int result = cmd.ExecuteNonQuery();

                done = result > 0;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return done;
        }



       
        public bool _updateClasseName(int _ClassID, string _newName)
        {
            bool done = true;

            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "update  tbClasses set className=@className where classID=@classID";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@className", _newName);
                cmd.Parameters.AddWithValue("@classID", _ClassID);

                int result = cmd.ExecuteNonQuery();

                done = result > 0;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return done;
        }

    }
}