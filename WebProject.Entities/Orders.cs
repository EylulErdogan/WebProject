using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core;

namespace WebProject.Entities
{
    public class Orders : IEntity
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public DateTime CreateDate { get; set; }
        public string? Phone { get; set; }
        public int? PaymentType { get; set; }
        public string? Address { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }


    }
}
