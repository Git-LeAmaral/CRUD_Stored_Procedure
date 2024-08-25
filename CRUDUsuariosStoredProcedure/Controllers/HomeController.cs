using CRUDUsuariosStoredProcedure.Data;
using CRUDUsuariosStoredProcedure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUDUsuariosStoredProcedure.Controllers
{
    public class HomeController : Controller
    {

        private readonly DataAccess _dataAccess;

        public HomeController(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public IActionResult Index()
        {

            try
            {
                var usuarios = _dataAccess.ListarUsuarios();
                return View(usuarios);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Ocorreu um erro na cria��o do usu�rio!";
                return View();
            }

        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var result = _dataAccess.Cadastrar(usuario);

                if (result)
                {
                    TempData["MensagemSucesso"] = "Usu�rio criado com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro na cria��o do usu�rio!";
                    return View(usuario);
                }
            }
            else
            {
                return View(usuario);
            }
        }

        public IActionResult Editar(int id)
        {
            var usuario = _dataAccess.BuscarUsuarioPorId(id);

            return View(usuario);
        }

        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var result = _dataAccess.Editar(usuario);

                if (result)
                {
                    TempData["MensagemSucesso"] = "Usu�rio editado com sucesso!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Ocorreu um erro na edi��o do usu�rio!";
                    return View(usuario);
                }
            }
            else
            {
                TempData["MensagemErro"] = "Ocorreu um erro na edi��o do usu�rio!";
                return View(usuario);
            }
        }

        public IActionResult Detalhes(int id)
        {
            var usuario = _dataAccess.BuscarUsuarioPorId(id);
            return View(usuario);
        }

        public IActionResult Remover(int id)
        {
            var result = _dataAccess.Remover(id);

            if (result)
            {
                TempData["MensagemSucesso"] = "Usu�rio removido com sucesso!";
            }
            else
            {
                TempData["MensagemErro"] = "Erro ao remover o usu�rio!";
            }
            return RedirectToAction("Index");
        }

    }
}
