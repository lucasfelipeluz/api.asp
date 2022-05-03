using System.Collections.Generic;

namespace Teste.Domain
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityCode { get; set; }
        public IEnumerable<Usuario> Moradores { get; set; }
    }
}