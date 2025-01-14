using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using ControleDeEstudantes.Data;
using ControleDeEstudantes.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstudantes.Models.Validations
{
    public class CpfValidationAttribute : ValidationAttribute
    {
        private readonly BancoContext _bancoContext;

       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string cpf = value.ToString().Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11 || !Regex.IsMatch(cpf, "^[0-9]{11}$"))
            {
                return new ValidationResult("CPF inválido(formato incorreto)");
            }

            int[] multiplicadores1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicadores2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores1[i];
            }

            int resto = soma % 11;
            int digito = (resto < 2) ? 0 : 11 - resto;

            if (int.Parse(cpf[9].ToString()) != digito)
            {
                return new ValidationResult("CPF inválido (dígito verificador incorreto).");
            }

            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(tempCpf[i].ToString()) * multiplicadores2[i];
            }

            resto = soma % 11;
            digito = (resto < 2) ? 0 : 11 - resto;

            if (int.Parse(cpf[10].ToString()) != digito)
            {
                return new ValidationResult("CPF inválido (dígito verificador incorreto).");
            }

            var serviceProvider = validationContext.GetService<IServiceProvider>();
            if (serviceProvider != null) 
            {
                using (var scope = serviceProvider.CreateScope())
                {
                    var bancoContext = scope.ServiceProvider.GetRequiredService<ControleDeEstudantes.Data.BancoContext>();
                    if (bancoContext != null)
                    {
                        bool cpfExiste = bancoContext.Estudantes.Any(e => e.CPF == cpf);

                        if (cpfExiste)
                        {
                            return new ValidationResult("CPF já cadastrado no sistema.");
                        }
                    }
                    else
                    {
                        return new ValidationResult("Erro ao obter o contexto do banco de dados."); // Mensagem de erro mais informativa
                    }

                }
            }
            else
            {
                return new ValidationResult("Erro ao obter o provedor de serviços."); // Mensagem de erro mais informativa
            }

            return ValidationResult.Success;
        }
    }
    }


