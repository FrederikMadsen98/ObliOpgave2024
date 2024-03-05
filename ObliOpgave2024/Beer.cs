using System.Net.Http.Headers;

namespace ObliOpgave2024
{
    public class Beer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Abv { get; set; }

        public override string ToString() => $"{Id} {Name} {Abv}";

        public void ValidateName()
        {
            if (Name is null)
            {
                throw new ArgumentNullException("Name is null");
            }
            if (Name.Length == 0)
            {
                throw new ArgumentException("Name is empty");
            }
            if (Name.Length <= 3)
            {
                throw new ArgumentOutOfRangeException("Name length must be greater than 3");
            }
        }

        public void ValidateAbv()
        {
            if (Abv < 0 || Abv > 67)
            {
                throw new ArgumentOutOfRangeException("Abv must be between 0 and 67");
            }
            if (Abv > 0 || Abv < 67)
            {
                throw new ArgumentException("Abv is valid");
            }
        }
        public void Validate()
        {
            ValidateName();
            ValidateAbv();
        }
    }
}
