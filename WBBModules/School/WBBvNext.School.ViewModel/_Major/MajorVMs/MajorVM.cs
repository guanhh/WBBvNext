using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WBBvNext.School.Model;


namespace WBBvNext.ViewModel._Major.MajorVMs
{
    public partial class MajorVM : BaseCRUDVM<Major>
    {
        [Display(Name = "学生")]
        public List<string> SelectedStudentMajorsIDs { get; set; }

        public MajorVM()
        {
            SetInclude(x => x.School);
            SetInclude(x => x.StudentMajors);
        }

        protected override void InitVM()
        {
            SelectedStudentMajorsIDs = Entity.StudentMajors?.Select(x => x.StudentId.ToString()).ToList();
        }

        public override void DoAdd()
        {
            Entity.StudentMajors = new List<StudentMajor>();
            if (SelectedStudentMajorsIDs != null)
            {
                foreach (var id in SelectedStudentMajorsIDs)
                {
                     StudentMajor middle = new StudentMajor();
                    middle.SetPropertyValue("StudentId", id);
                    Entity.StudentMajors.Add(middle);
                }
            }
           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            Entity.StudentMajors = new List<StudentMajor>();
            if(SelectedStudentMajorsIDs != null )
            {
                 foreach (var item in SelectedStudentMajorsIDs)
                {
                    StudentMajor middle = new StudentMajor();
                    middle.SetPropertyValue("StudentId", item);
                    Entity.StudentMajors.Add(middle);
                }
            }

            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
