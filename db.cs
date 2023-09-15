using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Crud_CR
{
    public class db:DbContext
    {
        public db():base("rt")
        {
            
        }
        public DbSet<human> Humans { get; set; }
    }
}
