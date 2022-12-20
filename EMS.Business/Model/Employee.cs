using System.ComponentModel.DataAnnotations;

namespace EMS.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        //[Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string FirstName { get; set; }

        //[Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string LastName { get; set; }

        //[Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string Email { get; set; }

        //[Required]
        public DateTime DateOfBirth { get; set; }

        //[Required]
        public int Age { get; set; }

        public DateTime JoinedDate { get; set; }

        public bool IsActive { get; set; }

        public int DepartmentId { get; set; }
    }
}
