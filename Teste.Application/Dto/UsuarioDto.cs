using System.ComponentModel.DataAnnotations;
using Teste.Domain;

namespace Teste.Application.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo {0} é obrigatório!")]
        public string Name { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public int Age { get; set; }
        public string Birth { get; set; }
    }

}
