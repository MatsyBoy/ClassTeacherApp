using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassTeacher_App.Managers
{
    public class ScoreandAvarageManager
    {

        public bool _setScorePerSubject(double score, int studentID, int subjectID)
        {
            bool done = true;

            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "insert into tbScores ( subjectID, studentID,score) values ( @subjectID, @studentID,@score)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@subjectID", subjectID);
                cmd.Parameters.AddWithValue("@studentID", studentID);
                cmd.Parameters.AddWithValue("@score", score);

                int result = cmd.ExecuteNonQuery();

                done = result > 0;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return done;
        }


        public StudentScore _calculateTotalScoreAndAvaragePerStudent(int studentID)
        {
            StudentScore _studentScore = new StudentScore();
            string query = string.Empty;
            try
            {
                MySqlConnection conn = new MySqlConnection(new DBConnection().connectionString);

                conn.Open();

                query = "select count(*) as counter, sum(score) as total from tbScores where studentID=@studentID group by studentID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@studentID", studentID);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                                     

                    _studentScore.studentID = studentID;
                   _studentScore.totalScore  = Convert.ToDouble(dataReader["total"]);
                    if( _studentScore.totalScore>0)
                    {
                    _studentScore.avarageScore = _studentScore.totalScore/Convert.ToInt16(dataReader["counter"]);
                   }
                }


                dataReader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return _studentScore;
        }

    }
}