using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using WBBvNext.&PlugName&.DataAccess;
using WBBvNext.Feedback.Controllers;
using WBBvNext.ViewModel._Feedback.SuggestionVMs;
using WBBvNext.Feedback.Model;
using WBBvNext.Feedback.DataAccess;


namespace WBBvNext.Test
{
    [TestClass]
    public class SuggestionApiTest
    {
        private SuggestionController _controller;
        private string _seed;

        public SuggestionApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<SuggestionController>(new FeedbackDBContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new SuggestionSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            SuggestionVM vm = _controller.Wtm.CreateVM<SuggestionVM>();
            Suggestion v = new Suggestion();
            
            v.Title = "8xgz8lP";
            v.Detail = "hbkCjDAMC";
            v.QuestionType = WBBvNext.Feedback.Model.QuestionTypeEnum.Suggestion;
            v.UserName = "xPtqN9DL";
            v.Email = "kX4mRJOx1";
            v.IsSolved = true;
            v.Remark = "QiCE9jfW";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new FeedbackDBContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Suggestion>().Find(v.ID);
                
                Assert.AreEqual(data.Title, "8xgz8lP");
                Assert.AreEqual(data.Detail, "hbkCjDAMC");
                Assert.AreEqual(data.QuestionType, WBBvNext.Feedback.Model.QuestionTypeEnum.Suggestion);
                Assert.AreEqual(data.UserName, "xPtqN9DL");
                Assert.AreEqual(data.Email, "kX4mRJOx1");
                Assert.AreEqual(data.IsSolved, true);
                Assert.AreEqual(data.Remark, "QiCE9jfW");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            Suggestion v = new Suggestion();
            using (var context = new FeedbackDBContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.Title = "8xgz8lP";
                v.Detail = "hbkCjDAMC";
                v.QuestionType = WBBvNext.Feedback.Model.QuestionTypeEnum.Suggestion;
                v.UserName = "xPtqN9DL";
                v.Email = "kX4mRJOx1";
                v.IsSolved = true;
                v.Remark = "QiCE9jfW";
                context.Set<Suggestion>().Add(v);
                context.SaveChanges();
            }

            SuggestionVM vm = _controller.Wtm.CreateVM<SuggestionVM>();
            var oldID = v.ID;
            v = new Suggestion();
            v.ID = oldID;
       		
            v.Title = "XCt7z";
            v.Detail = "9eS";
            v.QuestionType = WBBvNext.Feedback.Model.QuestionTypeEnum.Other;
            v.UserName = "werDw";
            v.Email = "D6Em3sOf";
            v.IsSolved = false;
            v.Remark = "Ddg";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.Title", "");
            vm.FC.Add("Entity.Detail", "");
            vm.FC.Add("Entity.QuestionType", "");
            vm.FC.Add("Entity.UserName", "");
            vm.FC.Add("Entity.Email", "");
            vm.FC.Add("Entity.IsSolved", "");
            vm.FC.Add("Entity.Remark", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new FeedbackDBContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<Suggestion>().Find(v.ID);
 				
                Assert.AreEqual(data.Title, "XCt7z");
                Assert.AreEqual(data.Detail, "9eS");
                Assert.AreEqual(data.QuestionType, WBBvNext.Feedback.Model.QuestionTypeEnum.Other);
                Assert.AreEqual(data.UserName, "werDw");
                Assert.AreEqual(data.Email, "D6Em3sOf");
                Assert.AreEqual(data.IsSolved, false);
                Assert.AreEqual(data.Remark, "Ddg");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            Suggestion v = new Suggestion();
            using (var context = new FeedbackDBContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.Title = "8xgz8lP";
                v.Detail = "hbkCjDAMC";
                v.QuestionType = WBBvNext.Feedback.Model.QuestionTypeEnum.Suggestion;
                v.UserName = "xPtqN9DL";
                v.Email = "kX4mRJOx1";
                v.IsSolved = true;
                v.Remark = "QiCE9jfW";
                context.Set<Suggestion>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            Suggestion v1 = new Suggestion();
            Suggestion v2 = new Suggestion();
            using (var context = new FeedbackDBContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.Title = "8xgz8lP";
                v1.Detail = "hbkCjDAMC";
                v1.QuestionType = WBBvNext.Feedback.Model.QuestionTypeEnum.Suggestion;
                v1.UserName = "xPtqN9DL";
                v1.Email = "kX4mRJOx1";
                v1.IsSolved = true;
                v1.Remark = "QiCE9jfW";
                v2.Title = "XCt7z";
                v2.Detail = "9eS";
                v2.QuestionType = WBBvNext.Feedback.Model.QuestionTypeEnum.Other;
                v2.UserName = "werDw";
                v2.Email = "D6Em3sOf";
                v2.IsSolved = false;
                v2.Remark = "Ddg";
                context.Set<Suggestion>().Add(v1);
                context.Set<Suggestion>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new FeedbackDBContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<Suggestion>().Find(v1.ID);
                var data2 = context.Set<Suggestion>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}
