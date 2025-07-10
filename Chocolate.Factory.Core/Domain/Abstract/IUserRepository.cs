using Chocolate.Factory.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chocolate.Factory.Core.Domain.Abstract
{
    public interface IUserRepository
    {
        void Add(User user);
        User GetByUsername(string username);
    }
}
