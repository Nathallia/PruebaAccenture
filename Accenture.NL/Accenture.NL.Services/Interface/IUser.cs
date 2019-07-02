using Accenture.NL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accenture.NL.Services.Interface
{
    public interface IUser
    {
        List<DtoUser> GetUsers();

        DtoUser GetUser(int id);
    }
}
