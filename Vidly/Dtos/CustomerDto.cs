using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        //Bad practice because it would couple the Dto to the domain object
        //It is better to create a seperate class called MembershipType Dto 
        //Then map them in the Mapping Profile
        //public MembershipType MembershipType { get; set; }
        public MembershipTypeDto MembershipType { get; set; }




        //        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}