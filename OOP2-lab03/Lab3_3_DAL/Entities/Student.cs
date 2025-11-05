using System;

namespace Lab3_3_DAL.Entities
{
    [Serializable]
    public class Student
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public int Course { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Residence { get; set; } = string.Empty;

        public bool LivesInDorm => Residence.Contains("-");

        public override string ToString() =>
            $"{LastName} {FirstName}, курс: {Course}, стать: {Gender}, проживання: {Residence}";
    }
}
