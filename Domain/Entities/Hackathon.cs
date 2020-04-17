using System;

namespace Domain.Entities
{
    public class Hackathon
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Theme { get; set; }

        public void ThrowIfInvalid()
        {
            if (string.IsNullOrEmpty(Name))
            {
                throw new ArgumentOutOfRangeException(nameof(Name));
            }

            if (string.IsNullOrEmpty(Theme))
            {
                throw new ArgumentOutOfRangeException(nameof(Theme));
            }
        }
    }
}