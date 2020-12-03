using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIEduX.Domains;
using APIEduX.Interfaces;
using APIEduX.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly iPerfil _perfilRepository;

        public PerfilController()
        {
            _perfilRepository = new PerfilRepository();
        }

        /// <summary>
        /// Lista os perfis existentes
        /// </summary>
        /// <returns>Lista de perfis</returns>
        [HttpGet]
        public List<Perfis> Get()
        {
            try
            {
                return _perfilRepository.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um perfil pelo Id
        /// </summary>
        /// <param name="id">Id buscado</param>
        /// <returns>Perfil correspondente ao Id</returns>
        [HttpGet("{id}")]
        public Perfis Get(Guid id)
        {
            try
            {
                return _perfilRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um novo perfil
        /// </summary>
        /// <param name="perfil">Perfil que será adicionado</param>
        [HttpPost]
        public void Post(Perfis perfil)
        {
            try
            {
                _perfilRepository.Adicionar(perfil);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um determinado perfil
        /// </summary>
        /// <param name="id">Novo Id do perfil</param>
        /// <param name="perfil">Perfil que será editado</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Perfis perfil)
        {
            try
            {
                perfil.IdPerfil = id;
                _perfilRepository.Editar(perfil);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deleta determinado perfil
        /// </summary>
        /// <param name="id">Id do perfil que será deletado</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                _perfilRepository.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
