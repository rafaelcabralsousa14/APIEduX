using APIEduX.Contexts;
using APIEduX.Domains;
using APIEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Repositories
{
    public class ProfessorTurmaRepository : iProfessorTurma
    {
        private readonly APIEduXContext _ctx;

        public ProfessorTurmaRepository()
        {
            _ctx = new APIEduXContext();
        }

        public void Adicionar(ProfessorTurmas professorTurma)
        {
            try
            {
                _ctx.ProfessorTurmas.Add(professorTurma);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public ProfessorTurmas BuscarPorId(Guid id)
        {
            try
            {
                ProfessorTurmas professorTurma = _ctx.ProfessorTurmas.Find(id);

                return professorTurma;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(ProfessorTurmas professorTurma)
        {
            try
            {
                ProfessorTurmas professorTurmaTemp = BuscarPorId(professorTurma.IdProfessorTurma);

                if (professorTurmaTemp == null)
                    throw new Exception("Professor não encontrado");

                professorTurmaTemp.IdUsuario = professorTurma.IdUsuario;
                professorTurmaTemp.IdTurma = professorTurma.IdTurma;

                _ctx.ProfessorTurmas.Update(professorTurmaTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProfessorTurmas> Listar()
        {
            try
            {
                List<ProfessorTurmas> professorTurmas = _ctx.ProfessorTurmas.ToList();

                return professorTurmas;
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
                ProfessorTurmas professorTurma = BuscarPorId(id);

                if (professorTurma == null)
                    throw new Exception("Professor não encontrado");

                _ctx.ProfessorTurmas.Remove(professorTurma);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
