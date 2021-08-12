using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WBBvNext.School.Controllers;
using WBBvNext.ViewModel._Major.MajorVMs;
using WBBvNext.School.Model;
using WBBvNext.Test;
using WBBvNext.DataAccess;
using WBBvNext.School.DataAccess;

namespace WBBvNext.School.Test
{
    [TestClass]
    public class MajorApiTest
    {
        private MajorController _controller;
        private string _seed;

        public MajorApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<MajorController>(new SchoolDBContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new MajorSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            MajorVM vm = _controller.Wtm.CreateVM<MajorVM>();
            Major v = new Major();
            
            v.MajorCode = "b6Z0a";
            v.MajorName = "SfGM8yq";
            v.Remark = "l3Z";
            v.SchoolId = AddSchool();
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Major>().Find(v.ID);
                
                Assert.AreEqual(data.MajorCode, "b6Z0a");
                Assert.AreEqual(data.MajorName, "SfGM8yq");
                Assert.AreEqual(data.Remark, "l3Z");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Major v = new Major();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.MajorCode = "b6Z0a";
                v.MajorName = "SfGM8yq";
                v.Remark = "l3Z";
                v.SchoolId = AddSchool();
                context.Set<Major>().Add(v);
                context.SaveChanges();
            }

            MajorVM vm = _controller.Wtm.CreateVM<MajorVM>();
            var oldID = v.ID;
            v = new Major();
            v.ID = oldID;
       		
            v.MajorCode = "yW4Nu";
            v.MajorName = "hJL";
            v.Remark = "SxWzXu";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.MajorCode", "");
            vm.FC.Add("Entity.MajorName", "");
            vm.FC.Add("Entity.Remark", "");
            vm.FC.Add("Entity.SchoolId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Major>().Find(v.ID);
 				
                Assert.AreEqual(data.MajorCode, "yW4Nu");
                Assert.AreEqual(data.MajorName, "hJL");
                Assert.AreEqual(data.Remark, "SxWzXu");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Major v = new Major();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.MajorCode = "b6Z0a";
                v.MajorName = "SfGM8yq";
                v.Remark = "l3Z";
                v.SchoolId = AddSchool();
                context.Set<Major>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Major v1 = new Major();
            Major v2 = new Major();
            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.MajorCode = "b6Z0a";
                v1.MajorName = "SfGM8yq";
                v1.Remark = "l3Z";
                v1.SchoolId = AddSchool();
                v2.MajorCode = "yW4Nu";
                v2.MajorName = "hJL";
                v2.Remark = "SxWzXu";
                v2.SchoolId = v1.SchoolId; 
                context.Set<Major>().Add(v1);
                context.Set<Major>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new SchoolDBContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Major>().Find(v1.ID);
                var data2 = context.Set<Major>().Find(v2.ID);
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

                v.SchoolCode = "A14";
                v.SchoolName = "WjnI44bz";
                v.SchoolType = WBBvNext.School.Model.SchoolTypeEnum.PRI;
                v.Remark = "InaK1tzYw";
                context.Set<WBBvNext.School.Model.School>().Add(v);
                context.SaveChanges();
                }
                catch{}
            }
            return v.ID;
        }


    }
}
