using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using WalkingTec.Mvvm.Core;
using WBBvNext.DataAccess;
using WBBvNext.School.Controllers;
using WBBvNext.School.DataAccess;
using WBBvNext.School.Model;
using WBBvNext.Test;
using WBBvNext.ViewModel._Student.StudentVMs;

namespace WBBvNext.School.Test
{
    [TestClass]
    public class StudentApiTest
    {
        private StudentController _controller;
        private string _seed;

        public StudentApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<StudentController>(new SchoolDBContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new StudentSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            StudentVM vm = _controller.Wtm.CreateVM<StudentVM>();
            Student v = new Student();
            
            v.LoginName = "5Mi";
            v.Password = "k2idJfkp7";
            v.Name = "yoCh";
            v.CellPhone = "SH57k";
            v.ZipCode = "vMo3FBU";
            v.PhotoId = AddFileAttachment();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Student>().Find(v.ID);
                
                Assert.AreEqual(data.LoginName, "5Mi");
                Assert.AreEqual(data.Password, "k2idJfkp7");
                Assert.AreEqual(data.Name, "yoCh");
                Assert.AreEqual(data.CellPhone, "SH57k");
                Assert.AreEqual(data.ZipCode, "vMo3FBU");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Student v = new Student();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.LoginName = "5Mi";
                v.Password = "k2idJfkp7";
                v.Name = "yoCh";
                v.CellPhone = "SH57k";
                v.ZipCode = "vMo3FBU";
                v.PhotoId = AddFileAttachment();
                context.Set<Student>().Add(v);
                context.SaveChanges();
            }

            StudentVM vm = _controller.Wtm.CreateVM<StudentVM>();
            var oldID = v.ID;
            v = new Student();
            v.ID = oldID;
       		
            v.LoginName = "SRPFhOMSP";
            v.Password = "Gya45";
            v.Name = "DiJtKoUZ";
            v.CellPhone = "ZMM0zC6";
            v.ZipCode = "UBBQXI";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.LoginName", "");
            vm.FC.Add("Entity.Password", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.CellPhone", "");
            vm.FC.Add("Entity.ZipCode", "");
            vm.FC.Add("Entity.PhotoId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Student>().Find(v.ID);
 				
                Assert.AreEqual(data.LoginName, "SRPFhOMSP");
                Assert.AreEqual(data.Password, "Gya45");
                Assert.AreEqual(data.Name, "DiJtKoUZ");
                Assert.AreEqual(data.CellPhone, "ZMM0zC6");
                Assert.AreEqual(data.ZipCode, "UBBQXI");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Student v = new Student();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.LoginName = "5Mi";
                v.Password = "k2idJfkp7";
                v.Name = "yoCh";
                v.CellPhone = "SH57k";
                v.ZipCode = "vMo3FBU";
                v.PhotoId = AddFileAttachment();
                context.Set<Student>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Student v1 = new Student();
            Student v2 = new Student();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.LoginName = "5Mi";
                v1.Password = "k2idJfkp7";
                v1.Name = "yoCh";
                v1.CellPhone = "SH57k";
                v1.ZipCode = "vMo3FBU";
                v1.PhotoId = AddFileAttachment();
                v2.LoginName = "SRPFhOMSP";
                v2.Password = "Gya45";
                v2.Name = "DiJtKoUZ";
                v2.CellPhone = "ZMM0zC6";
                v2.ZipCode = "UBBQXI";
                v2.PhotoId = v1.PhotoId; 
                context.Set<Student>().Add(v1);
                context.Set<Student>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Student>().Find(v1.ID);
                var data2 = context.Set<Student>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }

        private Guid AddFileAttachment()
        {
            FileAttachment v = new FileAttachment();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                try{

                v.FileName = "rWShefGe";
                v.FileExt = "mxXZ4NIK";
                v.Path = "qAkyo";
                v.Length = 52;
                v.SaveMode = "j5GBcSEKT";
                v.ExtraInfo = "elolg6Gvi";
                v.HandlerInfo = "Qz4q9Ri";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
