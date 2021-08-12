using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WBBvNext.School.Controllers;
using WBBvNext.ViewModel._School.SchoolVMs;
using WBBvNext.School.Model;
using WBBvNext.Test;
using WBBvNext.DataAccess;
using WBBvNext.School.DataAccess;

namespace WBBvNext.School.Test
{
    [TestClass]
    public class SchoolApiTest
    {
        private SchoolController _controller;
        private string _seed;

        public SchoolApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<SchoolController>(new SchoolDBContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new SchoolSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            SchoolVM vm = _controller.Wtm.CreateVM<SchoolVM>();
            WBBvNext.School.Model.School v = new WBBvNext.School.Model.School();
            
            v.SchoolCode = "j70";
            v.SchoolName = "MFCjjsD5";
            v.SchoolType = WBBvNext.School.Model.SchoolTypeEnum.PUB;
            v.PdfFileId = AddFileAttachment();
            v.Remark = "Chru4";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<WBBvNext.School.Model.School>().Find(v.ID);
                
                Assert.AreEqual(data.SchoolCode, "j70");
                Assert.AreEqual(data.SchoolName, "MFCjjsD5");
                Assert.AreEqual(data.SchoolType, WBBvNext.School.Model.SchoolTypeEnum.PUB);
                Assert.AreEqual(data.Remark, "Chru4");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            WBBvNext.School.Model.School v = new WBBvNext.School.Model.School();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.SchoolCode = "j70";
                v.SchoolName = "MFCjjsD5";
                v.SchoolType = WBBvNext.School.Model.SchoolTypeEnum.PUB;
                v.PdfFileId = AddFileAttachment();
                v.Remark = "Chru4";
                context.Set<WBBvNext.School.Model.School>().Add(v);
                context.SaveChanges();
            }

            SchoolVM vm = _controller.Wtm.CreateVM<SchoolVM>();
            var oldID = v.ID;
            v = new WBBvNext.School.Model.School();
            v.ID = oldID;
       		
            v.SchoolCode = "4Ag";
            v.SchoolName = "wWTUTQS";
            v.SchoolType = WBBvNext.School.Model.SchoolTypeEnum.PRI;
            v.Remark = "QFC";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.SchoolCode", "");
            vm.FC.Add("Entity.SchoolName", "");
            vm.FC.Add("Entity.SchoolType", "");
            vm.FC.Add("Entity.PdfFileId", "");
            vm.FC.Add("Entity.Remark", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<WBBvNext.School.Model.School>().Find(v.ID);
 				
                Assert.AreEqual(data.SchoolCode, "4Ag");
                Assert.AreEqual(data.SchoolName, "wWTUTQS");
                Assert.AreEqual(data.SchoolType, WBBvNext.School.Model.SchoolTypeEnum.PRI);
                Assert.AreEqual(data.Remark, "QFC");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            WBBvNext.School.Model.School v = new WBBvNext.School.Model.School();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.SchoolCode = "j70";
                v.SchoolName = "MFCjjsD5";
                v.SchoolType = WBBvNext.School.Model.SchoolTypeEnum.PUB;
                v.PdfFileId = AddFileAttachment();
                v.Remark = "Chru4";
                context.Set<WBBvNext.School.Model.School>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            WBBvNext.School.Model.School v1 = new WBBvNext.School.Model.School();
            WBBvNext.School.Model.School v2 = new WBBvNext.School.Model.School();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.SchoolCode = "j70";
                v1.SchoolName = "MFCjjsD5";
                v1.SchoolType = WBBvNext.School.Model.SchoolTypeEnum.PUB;
                v1.PdfFileId = AddFileAttachment();
                v1.Remark = "Chru4";
                v2.SchoolCode = "4Ag";
                v2.SchoolName = "wWTUTQS";
                v2.SchoolType = WBBvNext.School.Model.SchoolTypeEnum.PRI;
                v2.PdfFileId = v1.PdfFileId; 
                v2.Remark = "QFC";
                context.Set<WBBvNext.School.Model.School>().Add(v1);
                context.Set<WBBvNext.School.Model.School>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<WBBvNext.School.Model.School>().Find(v1.ID);
                var data2 = context.Set<WBBvNext.School.Model.School>().Find(v2.ID);
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

                v.FileName = "Owl";
                v.FileExt = "D6C5C";
                v.Path = "TYY";
                v.Length = 44;
                v.SaveMode = "gg737c5";
                v.ExtraInfo = "CWqU";
                v.HandlerInfo = "e8EA17N";
                context.Set<FileAttachment>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
