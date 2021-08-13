using Microsoft.EntityFrameworkCore;
using System;
using WalkingTec.Mvvm.Core;
using WBBvNext.School.Model;

namespace WBBvNext.School.DataAccess
{
    public class SchoolDBContext : EmptyContext
    {
        public DbSet<Major> Majors { get; set; }

        public DbSet<WBBvNext.School.Model.School> Schools { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentMajor> StudentMajors { get; set; }

        public DbSet<Company> Companies { get; set; }

        public SchoolDBContext(CS cs)
           : base(cs)
        {
        }

        public SchoolDBContext(string cs, DBTypeEnum dbtype)
            : base(cs, dbtype)
        {
        }

        public SchoolDBContext(string cs, DBTypeEnum dbtype, string version = null)
            : base(cs, dbtype, version)
        {
        }


        public SchoolDBContext(DbContextOptions<SchoolDBContext> options) : base(options) { }
    }
}
