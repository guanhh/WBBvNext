using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WBBvNext.School.Controllers;
using WBBvNext.ViewModel._StudentMajor.StudentMajorVMs;
using WBBvNext.School.Model;
using WBBvNext.Test;
using WBBvNext.DataAccess;
using WBBvNext.School.DataAccess;

namespace WBBvNext.School.Test
{
    [TestClass]
    public class StudentMajorApiTest
    {
        private StudentMajorController _controller;
        private string _seed;

        public StudentMajorApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<StudentMajorController>(new SchoolDBContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new StudentMajorSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            StudentMajorVM vm = _controller.Wtm.CreateVM<StudentMajorVM>();
            StudentMajor v = new StudentMajor();
            
            v.MajorId = AddMajor();
            v.StudentId = AddStudent();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StudentMajor>().Find(v.ID);
                
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            StudentMajor v = new StudentMajor();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.MajorId = AddMajor();
                v.StudentId = AddStudent();
                context.Set<StudentMajor>().Add(v);
                context.SaveChanges();
            }

            StudentMajorVM vm = _controller.Wtm.CreateVM<StudentMajorVM>();
            var oldID = v.ID;
            v = new StudentMajor();
            v.ID = oldID;
       		
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.MajorId", "");
            vm.FC.Add("Entity.StudentId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<StudentMajor>().Find(v.ID);
 				
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            StudentMajor v = new StudentMajor();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.MajorId = AddMajor();
                v.StudentId = AddStudent();
                context.Set<StudentMajor>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            StudentMajor v1 = new StudentMajor();
            StudentMajor v2 = new StudentMajor();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.MajorId = AddMajor();
                v1.StudentId = AddStudent();
                v2.MajorId = v1.MajorId; 
                v2.StudentId = v1.StudentId; 
                context.Set<StudentMajor>().Add(v1);
                context.Set<StudentMajor>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<StudentMajor>().Find(v1.ID);
                var data2 = context.Set<StudentMajor>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddSchool()
        {
            WBBvNext.School.Model.School v = new WBBvNext.School.Model.School();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.SchoolCode = "9Hx";
                v.SchoolName = "1oRUe2aA";
                v.SchoolType = WBBvNext.School.Model.SchoolTypeEnum.PUB;
                v.Remark = "VoB";
                context.Set<WBBvNext.School.Model.School>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddMajor()
        {
            Major v = new Major();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.MajorCode = "i5zjFhV";
                v.MajorName = "1LjRfB";
                v.Remark = "Lpgd9A";
                v.SchoolId = AddSchool();
                context.Set<Major>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddFileAttachment()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.FileName = "r4BSK5yp";
                v.FileExt = "fvkVF4";
                v.Path = "Tx7z2ofFV";
                v.Length = 98;
                v.SaveMode = "rX0UjCq";
                v.ExtraInfo = "sSBkatny";
                v.HandlerInfo = "7eZxk";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }

        private Guid AddStudent()
        {
            Student v = new Student();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.LoginName = "0VwCJ";
                v.Password = "ubyWlCmZ";
                v.Name = "lBHhyGd";
                v.CellPhone = "60jC46Ps";
                v.ZipCode = "x0N";
                v.PhotoId = AddFileAttachment();
                context.Set<Student>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
