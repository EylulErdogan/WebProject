using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Core;

namespace WebProject.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool Status { get; set; }
        public string? LoginGuidKey { get; set; }
        public bool IsAdmin{ get; set; }
    }


}
