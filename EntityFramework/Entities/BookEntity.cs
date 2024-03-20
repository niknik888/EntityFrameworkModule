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
        public int ReleaseYear { get; set; }
        public string Author { get; set; }
        public string Style { get; set; }

        public UserEntity Reader { get; set; }
    }
}
