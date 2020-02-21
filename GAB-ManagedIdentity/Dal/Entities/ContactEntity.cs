using System;

namespace GAB_ManagedIdentity.Dal.Entities
{
    public class ContactEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

}