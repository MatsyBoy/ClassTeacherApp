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




        ////Second branch----------------------------------------------------------------

        [OperationContract]
        Boolean updateClasseName(int _ClassID, string _newName);

        [OperationContract]
        Boolean updateStudentDetails(int _studentID, string _firstName, string _middleName, string _lastName, DateTime _dateOfBirth);

        [OperationContract]
        List<Subject> getSubjectsPerStudent(int studentID);

        [OperationContract]
        bool addSubjectToStudent(int studentID, int classID);



        //third branch----------------------------------------------------------------------------
        [OperationContract]
        List<Student> getStudentsBySubject(int subjectID);

        [OperationContract]
        List<Student> getStudentByLastName(string lastName);

        [OperationContract]
        Boolean setScorePerSubject(double score, int studentID, int subjectID);


        // fourth branch-----------------------------------------------------------------------------
        [OperationContract]
        StudentScore calculateTotalScoreAndAvaragePerStudent(int studentID);

        //[OperationContract]
        //Boolean calculateTotalScoreAvaragePerClass(int classID);

        ////[OperationContract]
        ////Boolean setScorePerStudent(double score, int studentID);

    }


}
