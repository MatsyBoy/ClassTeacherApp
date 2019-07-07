using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassTeacher_App.Managers
{
    public class SubjectsManager
    {

       
        public List<Subject> _getSubjectsPerStudent(int studentID)
        {
            List<Subject> subjects = new List<Subject>();
            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "select * from vw_SubjectsPerStudent where studentID=@studentID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    Subject _subject = new Subject();
                    _subject.subjectID = Convert.ToInt16(dataReader["subjectID"]);
                    _subject.subjectName = Convert.ToString(dataReader["subjectName"]);
                    
                    subjects.Add(_subject);
                }


                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return subjects;
        }


        public bool _addSubjectToStudent(int subjectID, int studentID)
        {
            bool done = true;

            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "insert into tbSubjectsPerStudent ( subjectID, studentID) values ( @subjectID, @studentID)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@subjectID", subjectID);
                cmd.Parameters.AddWithValue("@studentID", studentID);

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