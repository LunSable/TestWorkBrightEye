using System;
using System.Data.Entity;
using System.Linq;

namespace TestWork.DataModel
{
    public class NumbersContext : DbContext
    {

        public NumbersContext()
            : base("name=NumbersContext")
        {
        }
        public DbSet<Number> Numbers { get; set; }
        public DbSet<SortNumber> SortTable { get; set; }
    }


}