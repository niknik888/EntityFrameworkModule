using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string ReleaseYear { get; set; }
    }
}
