using Teste.Domain;

namespace Teste.API.Dto
{
    public class UsuarioDto 
    {
        public string Name { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public int Age { get; set; }
        public string Birth { get; set; }
    }
}