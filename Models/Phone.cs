using System;
namespace Models
{
    [Serializable]
    public class Phone
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
    }
}