using ControleDeEstudantes.Models;
using ControleDeEstudantes.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstudantes.Controllers
{
    public class EstudanteController : Controller
    {
        private readonly IEstudanteRepository _estudanteRepository;
        public EstudanteController(IEstudanteRepository estudanteRepository) 
        {
            _estudanteRepository = estudanteRepository;
        }
        public IActionResult Index()
        {
            var  estudantes =_estudanteRepository.FindAll();
            return View(estudantes);
        }
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {

            EstudanteModel estudante = _estudanteRepository.FindById(id);
            return View(estudante);
        }

        public IActionResult ExcluirConfirmacao(int id)
        {
            EstudanteModel estudante = _estudanteRepository.FindById(id);
            return View(estudante);
        }

        [HttpPost]
        public IActionResult Cadastrar(EstudanteModel estudante) 
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(estudante);
                }
                _estudanteRepository.Insert(estudante);
                TempData["MensagemSucesso"] = "Estudante cadastrado com sucesso";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Não foi possível cadastrar o estudante, tente novamente mais tarde.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(EstudanteModel estudante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _estudanteRepository.Update(estudante);
                    TempData["MensagemSucesso"] = "Estudante atualizado com sucesso";
                    return RedirectToAction("Index");
                    
                }
                return View("Editar",estudante);
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Não foi possível atualizar o estudante, tente novamente, mais informações: " + e.Message;
                return RedirectToAction("Index");
            }
        }

        
            

        
        public IActionResult Excluir(int id) {
            try
            {
               bool result = _estudanteRepository.Delete(id);
                if (result)
                {
                    TempData["MensagemSucesso"] = "Estudante excluido com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível excluir o estudante, tente novamente";
                }
               
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = "Não foi possível excluir o estudante, tente novamente, mais detalhes: " + e.Message;
                return RedirectToAction("Index");
            }

        
        }

    }
}
