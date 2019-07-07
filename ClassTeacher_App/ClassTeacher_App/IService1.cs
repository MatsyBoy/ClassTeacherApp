using ClassTeacher_App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClassTeacher_App
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {


        //First branch ----------------------------------------------------------------
        [OperationContract]
        List<Class> getAllTeacherClasses(int _teacherID);


        [OperationContract]
        bool addClassToTeacherClasses(int classID, int teacherID);


        [OperationContract]
        List<Student> getStudentsPerClass(int _classID);


        //[OperationContract]
        //bool addNewStudentToNewClass(Student _Student, Class _class);


    }


}
