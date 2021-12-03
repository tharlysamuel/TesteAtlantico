using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAtlantico.Domain.Entities;
using TesteAtlantico.Domain.Interfaces.Services;
using TesteAtlantico.Web.ViewModels;

namespace TesteAtlantico.Web.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _service.List();

            var viewModel = new List<UsuarioViewModel>();

            foreach (var item in usuarios)
            {
                var user = new UsuarioViewModel();
                user.Id = item.Id;
                user.Nome = item.Nome;
                user.Idade = item.Idade;

                viewModel.Add(user);
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = new UsuarioViewModel();

            var usuario = await _service.GetEntityById(id.Value);

            viewModel.Id = usuario.Id;
            viewModel.Nome = usuario.Nome;
            viewModel.Idade = usuario.Idade;

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {

            UsuarioCreateViewModel usuarioCreateViewModel = new UsuarioCreateViewModel();

            return View(usuarioCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UsuarioCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario();

                usuario.Nome = viewModel.Nome;
                usuario.Senha = viewModel.Senha;
                usuario.Idade = viewModel.Idade;
                await _service.Add(usuario);

                return RedirectToAction(nameof(Index));

            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _service.GetEntityById(id.Value);

            if (usuario == null)
            {
                return NotFound();
            }

            var viewModel = new UsuarioCreateViewModel();
            viewModel.Id = usuario.Id;
            viewModel.Nome = usuario.Nome;
            viewModel.Senha = usuario.Senha;
            viewModel.Idade = usuario.Idade;

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UsuarioCreateViewModel viewModel)
        {       
            if (ModelState.IsValid)
            {
                try
                {
                    var usuario = await _service.GetEntityById(viewModel.Id);

                    usuario.Nome = viewModel.Nome;
                    usuario.Senha = viewModel.Senha;
                    usuario.Idade = viewModel.Idade;

                    await _service.Update(usuario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _service.GetEntityById(id.Value);

            if (usuario == null)
            {
                return NotFound();
            }

            var viewModel = new UsuarioViewModel();
            viewModel.Id = usuario.Id;
            viewModel.Nome = usuario.Nome;
            viewModel.Idade = usuario.Idade;

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }



    }
}
