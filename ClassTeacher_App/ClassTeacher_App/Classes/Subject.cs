using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClassTeacher_App
{
    [DataContract]
    public class Subject
    {
       public int subjectID { get; set; }
        public string subjectName { get; set; }
    }
}