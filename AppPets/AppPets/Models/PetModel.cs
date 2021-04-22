using System;
using System.Collections.Generic;
using System.Text;

namespace AppPets.Models
{
    public class PetModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }

        public string ImageBase64 { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

    }
}
