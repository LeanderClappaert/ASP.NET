using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerDetailViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public MembershipType MembershipType { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}