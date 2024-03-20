using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Entities
{
    public class CompanyEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<UserEntity> Users { get; set; }
    }

}
