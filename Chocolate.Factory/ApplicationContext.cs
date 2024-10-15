using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chocolate.Factory.Core.DataAcces.SQLServer;
using Chocolate.Factory.Core.Domain.Abstract;

namespace Chocolate.Factory
{
    internal class ApplicationContext
    {
        public static IUnitOfWork UnitOfWork { get; private set; }


        public static void Initialize()
        {
            UnitOfWork = new SqlUnitOfWork("");
        }
    }
}
