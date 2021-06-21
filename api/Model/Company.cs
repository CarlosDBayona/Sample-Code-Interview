
using System;

namespace api.Model
{
    public class Company
    {
        public Guid Id { get; set; }
        
        public int Nit { get; set; }
        
        public string CompanyName { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string FirstLastName { get; set; }

        public string SecondLastName { get; set; }

        public string Email { get; set; }

        public bool AuthorizeMessagesPhone { get; set; }

        public bool AuthorizeMessagesEmail { get; set; }

        public int IdentificationTypeId { get; set; }
        
        public IdentificationType IdentificationType { get; set; }
    }
}