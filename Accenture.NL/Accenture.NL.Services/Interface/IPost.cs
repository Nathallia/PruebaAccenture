using Accenture.NL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accenture.NL.Services.Interface
{
    public interface IPost
    {
        List<DtoPost> GetPostsByUserId(int userId);
    }
}
