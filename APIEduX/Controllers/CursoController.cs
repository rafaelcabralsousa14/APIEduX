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
    public class CursoController : ControllerBase
    {
        private readonly iCurso _cursoRepository;

        public CursoController()
        {
            _cursoRepository = new CursoRepository();
        }

        /// <summary>
        /// Lista os cursos adicionados
        /// </summary>
        /// <returns>Lista de cursos</returns>
        [HttpGet]
        public List<Cursos> Get()
        {
            try
            {
                return _cursoRepository.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca curso por seu Id
        /// </summary>
        /// <param name="id">Id do curso buscado</param>
        /// <returns>Curso com o Id buscado</returns>
        [HttpGet("{id}")]
        public Cursos Get(Guid id)
        {
            try
            {
                return _cursoRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um novo curso
        /// </summary>
        /// <param name="curso">Curso que será adicionado</param>
        /// <returns></returns>
        [HttpPost]
        public void Post(Cursos curso)
        {
            try
            {
                _cursoRepository.Adicionar(curso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita um curso existente
        /// </summary>
        /// <param name="id">Id nova do curso</param>
        /// <param name="curso">Curso que será editado</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Cursos curso)
        {
            try
            {
                curso.IdCurso = id;
                _cursoRepository.Editar(curso);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove curso existente
        /// </summary>
        /// <param name="id">Id do curso que será deletado</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                _cursoRepository.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
