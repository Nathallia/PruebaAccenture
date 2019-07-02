using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accenture.NL.Models
{
    public class DtoAlbum
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DtoUser User { get; set; }
        
        public List<DtoPhoto> Photos { get; set; }
    }
}
