using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class CustomRole : IdentityRole
    {
        public CustomRole() : base() { }
        public CustomRole(string roleName) : base(roleName) { }
        [ForeignKey("Departmant")]
        public int? DepartmentId { get; set; }
        public virtual Departmant Departmant { get; set; }



    }
}
