using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIEduX.Domains;
using APIEduX.Interfaces;
using APIEduX.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIEduX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetivoAlunoController : ControllerBase
    {
        private readonly iObjetivoAluno _objetivoalunoRepository;

        public ObjetivoAlunoController()
        {
            _objetivoalunoRepository = new ObjetivoAlunoRepository();
        }

        /// <summary>
        /// Lista os objetivos de cada aluno
        /// </summary>
        /// <returns>Lista de objetivos de cada aluno</returns>
        [HttpGet]
        public List<ObjetivoAlunos> Get()
        {
            try
            {
                return _objetivoalunoRepository.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Busca determinado objetivo por seu Id
        /// </summary>
        /// <param name="id">Id buscado</param>
        /// <returns>Objetivo com o Id pesquisado</returns>
        [HttpGet("{id}")]
        public ObjetivoAlunos Get(Guid id)
        {
            try
            {
                return _objetivoalunoRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize(Roles = "Professor")]
        /// <summary>
        /// Adiciona um novo objetivo para determinado aluno
        /// </summary>
        /// <param name="objetivoaluno">Objetivo que será adicionado</param>
        [HttpPost]
        public void Post(ObjetivoAlunos objetivoaluno)
        {
            try
            {
                _objetivoalunoRepository.Adicionar(objetivoaluno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize(Roles = "Professor")]
        /// <summary>
        /// Edita determinado objetivo
        /// </summary>
        /// <param name="id">Id novo do objeitvo</param>
        /// <param name="objetivoaluno">Objetivo que será editado</param>
        [HttpPut("{id}")]
        public void Put(Guid id, ObjetivoAlunos objetivoaluno)
        {
            try
            {
                objetivoaluno.IdObjetivoAluno = id;
                _objetivoalunoRepository.Editar(objetivoaluno);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [Authorize(Roles = "Professor")]
        /// <summary>
        /// Deleta determinado objetivo
        /// </summary>
        /// <param name="id">Id do objetivo que será deletado</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                _objetivoalunoRepository.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
