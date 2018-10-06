using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Min18YearsIfMember]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribed { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer, IEnumerable<MembershipType> membershipTypes)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            BirthDate = customer.BirthDate;
            IsSubscribed = customer.IsSubscribed;
            MembershipTypeId = customer.MembershipTypeId;
            MembershipTypes = membershipTypes;

        }

        public CustomerFormViewModel(IEnumerable<MembershipType> membershipTypes)
        {
            Id = 0;
            MembershipTypes = membershipTypes;
        }

        public Customer ToCustomer()
        {
            return new Customer
            {
                Id = Id.Value,
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = BirthDate,
                IsSubscribed= IsSubscribed,
                MembershipTypeId= MembershipTypeId.Value,
            };
        }

    }
}