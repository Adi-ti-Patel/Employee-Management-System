using System.ComponentModel.DataAnnotations;

namespace EMS.Model
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
