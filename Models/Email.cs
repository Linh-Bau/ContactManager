using System;
namespace Models
{
    [Serializable]
    public class Email
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string EmailAddress { get; set; }
    }
}