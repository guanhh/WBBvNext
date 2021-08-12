using Microsoft.EntityFrameworkCore;
using System;
using WalkingTec.Mvvm.Core;
using WBBvNext.Feedback.Model;

namespace WBBvNext.Feedback.DataAccess
{
    public class FeedbackDBContext : FrameworkContext
    {
        //此处定义你的DbSet

        public DbSet<Suggestion> Suggestions { get; set; }
        public FeedbackDBContext(CS cs)
           : base(cs)
        {
        }

        public FeedbackDBContext(string cs, DBTypeEnum dbtype)
            : base(cs, dbtype)
        {
        }

        public FeedbackDBContext(string cs, DBTypeEnum dbtype, string version = null)
            : base(cs, dbtype, version)
        {
        }


        public FeedbackDBContext(DbContextOptions<FeedbackDBContext> options) : base(options) { }
    }
}
