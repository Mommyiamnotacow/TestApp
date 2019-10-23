namespace DAL.Context
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DateMatchDB : DbContext
    {
        public DateMatchDB()
            : base("name=DateMatchDB")
        {
        }

        public virtual DbSet<Intervals> Intervals { get; set; }
        public virtual DbSet<LogRecords> LogRecords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
