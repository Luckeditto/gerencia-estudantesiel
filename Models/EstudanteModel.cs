using System.ComponentModel.DataAnnotations;
using ControleDeEstudantes.Data;
using ControleDeEstudantes.Models.Validations;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstudantes.Models
{
    [Index(nameof(EstudanteModel.CPF), IsUnique = true)]
    public class EstudanteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o Nome")]
        [StringLength(100, ErrorMessage = "O nome deve ter entre {2} e {1} caracteres.", MinimumLength = 3)]
        public required string Name { get; set; }


        [Required(ErrorMessage = "É obrigatorio informar o CPF")]
        [CpfValidation(ErrorMessage ="CPF Inválido")]
        public required string CPF { get; set; }


        [Required(ErrorMessage = "Digite o endereço")]
        [StringLength(200, ErrorMessage = "O endereço deve ter entre {2} e {1} caracteres.", MinimumLength = 5)]
        public required string Endereco { get; set; }


        [Required(ErrorMessage = "Escolha a data de conclusão ou a data prevista para conclusão")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string DataConclusao { get; set; }
    }
}
