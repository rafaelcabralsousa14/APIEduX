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
    public class CurtidaController : ControllerBase
    {
        private readonly iCurtida _curtidaRepository;

        public CurtidaController()
        {
            _curtidaRepository = new CurtidaRepository();
        }

        /// <summary>
        /// Lê as curtidas das Dicas
        /// </summary>
        /// <returns>Curtidas</returns>
        [HttpGet]
        public List<Curtidas> Get()
        {
            try
            {
                return _curtidaRepository.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca o Id de uma Curtida específica
        /// </summary>
        /// <param name="id">Id da Curtida</param>
        /// <returns>Curtida com o Id pesquisado</returns>
        [HttpGet("{id}")]
        public Curtidas Get(Guid id)
        {
            try
            {
                return _curtidaRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona uma nova curtida
        /// </summary>
        /// <param name="curtida">Curtida a ser adicionada</param>
        [HttpPost]
        public void Post(Curtidas curtida)
        {
            try
            {
                _curtidaRepository.Adicionar(curtida);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Deleta curtida pelo Id
        /// </summary>
        /// <param name="id">Id da curtida que será excluída</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _curtidaRepository.Remover(id);
        }
    }
}
