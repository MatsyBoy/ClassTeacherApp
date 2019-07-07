using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ClassTeacher_App
{
    [DataContract]
    public class Teacher : Person
    {
        private int teacherID;
 public int _teacherID
    {
get
        {return this.teacherID;}

        set
        {
                if (value<=0) { throw new Exception("invalid teacher id."); }
                teacherID = value;
            }
    }

    }

   
        

}