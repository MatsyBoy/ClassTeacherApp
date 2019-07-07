using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClassTeacher_App
{
    [DataContract]
    public class Class
    {
        public int classID { get; set; }
       // public int teacherID { get; set; }
       // public int subjectID { get; set; }
        public string className { get; set; }
        public int yearOfCreation { get; set; }
        
    }

    public class ClassAvarage
    {
        public int classID;

        private double score;

        private double avarage;
    }
}