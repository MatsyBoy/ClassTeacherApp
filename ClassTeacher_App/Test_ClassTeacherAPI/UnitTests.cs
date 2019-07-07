using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassTeacherAPI;

namespace Test_ClassTeacherAPI
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void getAllTeacherClasses_teacherIDIsValid_true()
        {
            Teacher _teacher = new Teacher();

            _teacher.firstName = "Franklin";
            _teacher.lastName = "Bosh";
            _teacher._teacherID = 1000;

            Assert.IsTrue(_teacher._teacherID > 0, "OK");

        }


        [TestMethod]
        public void setNewClass_inputData_true()
        {
            Class _Class=new Class();

            _Class.className = "Anthropology";
            _Class.yearOfCreation = 2018;

            Assert.IsTrue(!string.IsNullOrWhiteSpace(_Class.className),"OK");
           
            Assert.IsTrue(_Class.yearOfCreation > 1901, "Year is ok");
        }

               
      
            [TestMethod]
            public void getStudentsPerClass_classIDIsValid_true()
            {
               Class _class = new Class();

            _class.classID = 9;
            _class.className = "Chemistry";
           

                Assert.IsTrue(_class.classID > 0, "OK");

            }

        }
}
