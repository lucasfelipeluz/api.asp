using System;
using System.ComponentModel.DataAnnotations;

namespace Teste.Domain
{
    public class Usuario
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public int Age { get; set; }
        public DateTime? Birth { get; set; }
    }
}