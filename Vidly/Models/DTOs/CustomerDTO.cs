using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        public string Name { get { return $"{FirstName} {LastName}"; } }

      //  [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribed { get; set; }

        public byte MembershipTypeId { get; set; }

    }
}