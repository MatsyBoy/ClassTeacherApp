using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassTeacher_App.Managers
{
    public class StudentsManager
    {

        public List<Student> _getStudentsPerClass(int _classID)
        {
            List<Student> students = new List<Student>();
            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "select * from vw_StudentsPerClass where classID=@classID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@classID", _classID);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    Student _student = new Student();
                    _student.studentID = Convert.ToInt16(dataReader["studentID"]);
                    _student.firstName  = Convert.ToString(dataReader["firstName"]);
                    _student.middleName = Convert.ToString(dataReader["middleName"]);
                    _student.lastName=Convert.ToString(dataReader["lastName"]);
                    _student.gender = Convert.ToString(dataReader["gender"]);
                    _student.dateOfBirth = Convert.ToDateTime(dataReader["dateOfBirth"]);


                    students.Add(_student);
                }

              
                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return students;
        }



        public bool _addNewStudent(Student _student)
        {
            bool done = true;

            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "insert into tbStudents ( firstName, middleName,lastName,gender,dateOfBirth) values ( @firstName, @middleName,@lastName,@gender,@dateOfBirth)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
               
                cmd.Parameters.AddWithValue("@firstName", _student.firstName);
                cmd.Parameters.AddWithValue("@middleName", _student.middleName);
                cmd.Parameters.AddWithValue("@lastName", _student.lastName);
                cmd.Parameters.AddWithValue("@gender", _student.gender);
                cmd.Parameters.AddWithValue("@dateOfBirth", _student.dateOfBirth);
                

                int result = cmd.ExecuteNonQuery();

                done = result > 0;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return done;
        }


        public bool _addStudenToClasse(int classID, int studentID)
        {
            bool done = true;

            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "insert into tbStudentsPerClass ( classID, studentID) values ( @classID, @studentID)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@classID", classID);
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


        public bool _updateStudentDetails(int _studentID, string _firstName,string _middleName, string _lastName,DateTime _dateOfBirth)
        {
            bool done = true;

            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "update  tbStudents set firstName=@firstName,middleName=@middleName,lastName=@lastName,dateOfBirth=@dateOfBirth where studentID=@studentID";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@firstName", _firstName);
                cmd.Parameters.AddWithValue("@middleName", _middleName);
                cmd.Parameters.AddWithValue("@lastName", _lastName);
                cmd.Parameters.AddWithValue("@dateOfBirth", _dateOfBirth);
                cmd.Parameters.AddWithValue("@studentID", _studentID);
                

                int result = cmd.ExecuteNonQuery();

                done = result > 0;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return done;
        }


        public List<Student> _getStudentsPerSubject(int subjectID)
        {
            List<Student> students = new List<Student>();
            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "select * from vw_SubjectsPerStudent where subjectID=@subjectID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@subjectID", subjectID);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    Student _student = new Student();

                    _student.studentID = Convert.ToInt16(dataReader["studentID"]);
                    _student.firstName = Convert.ToString(dataReader["firstName"]);
                    _student.middleName = Convert.ToString(dataReader["middleName"]);
                    _student.lastName = Convert.ToString(dataReader["lastName"]);
                    _student.gender = Convert.ToString(dataReader["gender"]);
                    _student.dateOfBirth = Convert.ToDateTime(dataReader["dateOfBirth"]);

                    students.Add(_student);
                }


                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return students;
        }



        public List<Student> _getStudentByLastName(string lastName)
        {
            List<Student> students = new List<Student>();
            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "select * from tbStudents where lastName like '%" + lastName  + "%'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
               // cmd.Parameters.AddWithValue("@lastName", lastName);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {

                    Student _student = new Student();

                    _student.studentID = Convert.ToInt16(dataReader["studentID"]);
                    _student.firstName = Convert.ToString(dataReader["firstName"]);
                    _student.middleName = Convert.ToString(dataReader["middleName"]);
                    _student.lastName = Convert.ToString(dataReader["lastName"]);
                    _student.gender = Convert.ToString(dataReader["gender"]);
                    _student.dateOfBirth = Convert.ToDateTime(dataReader["dateOfBirth"]);

                    students.Add(_student);
                }


                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return students;
        }
    }
}