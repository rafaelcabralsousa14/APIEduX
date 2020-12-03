using APIEduX.Contexts;
using APIEduX.Domains;
using APIEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Repositories
{
    public class CursoRepository : iCurso
    {
        private readonly APIEduXContext _ctx;
        public CursoRepository()
        {
            _ctx = new APIEduXContext();
        }

        public void Adicionar(Cursos curso)
        {
            try
            {
                _ctx.Cursos.Add(curso);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Cursos BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Cursos.FirstOrDefault(c => c.IdCurso == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Cursos curso)
        {
            try
            {
                Cursos cursoTemp = BuscarPorId(curso.IdCurso);

                if (cursoTemp == null)
                    throw new Exception("Curso não encontrado");

                cursoTemp.Titulo = curso.Titulo;


                _ctx.Cursos.Update(cursoTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Cursos> Listar()
        {
            try
            {
                return _ctx.Cursos.ToList();
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
                Cursos cursoTemp = BuscarPorId(id);

                if (cursoTemp == null)
                    throw new Exception("Curso não encontrado");

                _ctx.Cursos.Remove(cursoTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
