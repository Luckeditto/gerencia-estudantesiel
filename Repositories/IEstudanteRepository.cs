using ControleDeEstudantes.Models;

namespace ControleDeEstudantes.Repositories
{
    public interface IEstudanteRepository
    {
        EstudanteModel FindById(int id);
        List<EstudanteModel> FindAll();
        EstudanteModel Insert(EstudanteModel estudante);
        EstudanteModel Update(EstudanteModel estudante);
        bool Delete(int id);    


    }
}
