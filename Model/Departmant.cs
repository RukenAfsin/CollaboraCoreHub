using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Departmant
    {

        [Key]
        public int DepartmantId { get; set; }
        [Display(Name = "Departman Adı")]
        public string? DepartmantName { get; set; }
        public virtual List<CustomRole>? Roles { get; set; }




    }
}
