using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Teste.Domain;

namespace Teste.Application.Dto
{
    public class CityDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da cidade é obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Código da cidade é obrigatório!")]
        public int CityCode { get; set; }
    }
}
