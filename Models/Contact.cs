using System;
using System.Collections.Generic;
namespace Models
{
    [Serializable]
    public class Contact
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public List<Email> Emails { get; set; } = new List<Email>();
        public List<Phone> Phones { get; set; } = new List<Phone>();
    }
}