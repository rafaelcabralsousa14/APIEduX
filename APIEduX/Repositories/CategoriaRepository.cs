using APIEduX.Contexts;
using APIEduX.Domains;
using APIEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Repositories
{
    public class CategoriaRepository : iCategoria
    {
        private readonly APIEduXContext _ctx;
        public CategoriaRepository()
        {
            _ctx = new APIEduXContext();
        }

        public void Adicionar(Categorias categoria)
        {
            try
            {
                _ctx.Categorias.Add(categoria);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Categorias BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Categorias.FirstOrDefault(c => c.IdCategoria == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Categorias categoria)
        {
            try
            {
                Categorias categoriaTemp = BuscarPorId(categoria.IdCategoria);

                if (categoriaTemp == null)
                    throw new Exception("Categoria não encontrada");

                categoriaTemp.Tipo = categoria.Tipo;

                _ctx.Categorias.Update(categoriaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Categorias> Listar()
        {
            try
            {
                return _ctx.Categorias.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public void Remover(Guid id)
        {
            try
            {
                Categorias categoriaTemp = BuscarPorId(id);

                if (categoriaTemp == null)
                    throw new Exception("Categoria não encontrada");

                _ctx.Categorias.Remove(categoriaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
