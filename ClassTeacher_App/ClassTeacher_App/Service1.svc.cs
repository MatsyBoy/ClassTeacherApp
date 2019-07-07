using ClassTeacher_App;
using ClassTeacher_App.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ClassTeacher_App
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public List<Class> getAllTeacherClasses(int _teacherID)
        {
            List<Class> classes = new List<Class>();
            TeachersManager manager = new Managers.TeachersManager();
            try
            {

                classes = manager._getAllTeacherClasses(_teacherID: _teacherID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return classes;
        }


        public bool addClassToTeacherClasses(int classID, int teacherID)
        {
            bool done = true;

            try
            {
                ClassesManager manager = new ClassesManager();

                done = manager._addClassToTeacherClasses(classID: classID, teacherID: teacherID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return done;
        }


        public List<Student> getStudentsPerClass(int _classID)
        {
            List<Student> students = new List<Student>();
            StudentsManager manager = new StudentsManager();
            try
            {

                students = manager._getStudentsPerClass(_classID: _classID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return students;
        }


        //did not understand quite well
        //public bool addNewStudentToNewClass(Student _Student, Class _class)
        //{

        //    bool studentInserted = true;
        //    bool classInserted = true;
        //    bool done = true;

        //    try
        //    {
        //        ClassesManager _classManager = new ClassesManager();
        //        StudentsManager _studentManager = new StudentsManager();

        //        classInserted = _classManager._addNewClass(_Class: _class);
        //        studentInserted = _studentManager._addNewStudent(_student: _Student);

        //        if (studentInserted && classInserted)
        //        {
        //            done = _studentManager._addStudenToClasse(classID: _class.classID, studentID: _Student.studentID);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }


        //    return done;

        //} 


        //version2.0----------------------------------------------------------------------------
        public Boolean updateClasseName(int _ClassID, string _newName)
        {
            bool done = true;
            try
            {
                ClassesManager _classManager = new ClassesManager();

                done = _classManager._updateClasseName(_ClassID: _ClassID, _newName: _newName);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return done;
        }


        public Boolean updateStudentDetails(int _studentID, string _firstName, string _middleName, string _lastName, DateTime _dateOfBirth)
        {
            bool done = true;

            try
            {
                StudentsManager _studentsManager = new StudentsManager();

                done = _studentsManager._updateStudentDetails(_studentID: _studentID,
                                                               _firstName: _firstName,
                                                                _middleName: _middleName,
                                                                 _lastName: _lastName,
                                                                  _dateOfBirth: _dateOfBirth);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return done;
        }


        public List<Subject> getSubjectsPerStudent(int studentID)
        {
            List<Subject> subjects = new List<Subject>();

            try
            {
                SubjectsManager _subjectsManager = new SubjectsManager();

                subjects = _subjectsManager._getSubjectsPerStudent(studentID: studentID);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return subjects;
        }


        public bool addSubjectToStudent(int studentID, int subjectID)
        {
            bool done = true;

            try
            {
                SubjectsManager manager = new SubjectsManager();

                done = manager._addSubjectToStudent(studentID: studentID, subjectID: subjectID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return done;

        }

    }
}
