using ControleDeEstudantes.Data;
using ControleDeEstudantes.Models;

namespace ControleDeEstudantes.Repositories
{
    public class EstudanteRepository : IEstudanteRepository
    {
        private readonly BancoContext _bancoContext;
        public EstudanteRepository(BancoContext bancoContext) 
        {
            _bancoContext = bancoContext;
        }

        public EstudanteModel FindById(int id)
        {
            var estudante = _bancoContext.Estudantes.FirstOrDefault(x => x.Id == id);
            if (estudante == null)
            {
                throw new KeyNotFoundException("Estudante não encontrado");
            }
            return estudante;
        }

        public List<EstudanteModel> FindAll()
        {
            return _bancoContext.Estudantes.ToList();
        }

  

        public EstudanteModel Insert(EstudanteModel estudante)
        {
            _bancoContext.Estudantes.Add(estudante);
            _bancoContext.SaveChanges();
            return estudante;
        }

        public EstudanteModel Update(EstudanteModel estudante)
        {
            EstudanteModel estudanteDB = FindById(estudante.Id);

            if (estudanteDB == null)
            {
                throw new KeyNotFoundException("Id não equivale a nenhum registro");
            }

            estudanteDB.Name = estudante.Name;
            estudanteDB.CPF = estudante.CPF;
            estudanteDB.Endereco = estudante.Endereco;
            estudanteDB.DataConclusao = estudante.DataConclusao;

            _bancoContext.Update(estudanteDB);
            _bancoContext.SaveChanges();
            return estudanteDB;
        }

        public bool Delete(int id)
        {
            EstudanteModel estudanteDB = FindById(id);

            if (estudanteDB == null)
            {
                throw new KeyNotFoundException("Erro na exclusão do registro");
            }

            _bancoContext.Estudantes.Remove(estudanteDB);
            _bancoContext.SaveChanges();
            return true;

        }
    }
}
