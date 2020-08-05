using System;
using System.Collections.Generic;
using System.Text;
using Tomskeda.Core.Entities;

namespace Tomskeda.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        bool IsAccountExist(User user);
    }
}
