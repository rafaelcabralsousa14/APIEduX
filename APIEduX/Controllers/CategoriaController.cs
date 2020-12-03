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
    public class CategoriaController : ControllerBase
    {
        private readonly iCategoria _categoriaRepository;

        public CategoriaController()
        {
            _categoriaRepository = new CategoriaRepository();
        }

        /// <summary>
        /// Lista as categorias adicionadas
        /// </summary>
        /// <returns>Lista de categorias</returns>
        [HttpGet]
        public List<Categorias> Get()
        {
            try
            {
                return _categoriaRepository.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Busca categoria por seu Id
        /// </summary>
        /// <param name="id">Id da categoria buscada</param>
        /// <returns>Categoria com o Id buscado</returns>
        [HttpGet("{id}")]
        public Categorias Get(Guid id)
        {
            try
            {
                return _categoriaRepository.BuscarPorId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona uma nova categoria
        /// </summary>
        /// <param name="categoria">Categoria que será adicionada</param>
        [HttpPost]
        public void Post(Categorias categoria)
        {
            try
            {
                _categoriaRepository.Adicionar(categoria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Edita uma categoria existente
        /// </summary>
        /// <param name="id">Id nova da categoria</param>
        /// <param name="categoria">Categoria que será editada</param>
        [HttpPut("{id}")]
        public void Put(Guid id, Categorias categoria)
        {
            try
            {
                categoria.IdCategoria = id;
                _categoriaRepository.Editar(categoria);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Remove uma categoria existente
        /// </summary>
        /// <param name="id">Id da categoria que será deletada</param>
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            try
            {
                _categoriaRepository.Remover(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
