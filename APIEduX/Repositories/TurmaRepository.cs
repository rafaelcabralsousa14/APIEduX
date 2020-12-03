using APIEduX.Contexts;
using APIEduX.Domains;
using APIEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Repositories
{
    public class TurmaRepository : iTurma
    {
        private readonly APIEduXContext _ctx;

        public TurmaRepository()
        {
            _ctx = new APIEduXContext();
        }

        public void Adicionar(Turmas turma)
        {
            try
            {
                _ctx.Turmas.Add(turma);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Turmas BuscarPorId(Guid id)
        {
            try
            {
                Turmas turma = _ctx.Turmas.Find(id);

                return turma;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Turmas turma)
        {
            try
            {
                Turmas turmaTemp = BuscarPorId(turma.IdTurma);

                if (turmaTemp == null)
                    throw new Exception("Turma não encontrada");

                turmaTemp.IdTurma = turma.IdTurma;

                _ctx.Turmas.Update(turmaTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Turmas> Listar()
        {
            try
            {
                List<Turmas> turmas = _ctx.Turmas.ToList();

                return turmas;
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
                Turmas turma = BuscarPorId(id);

                if (turma == null)
                    throw new Exception("Turma não encontrada");

                _ctx.Turmas.Remove(turma);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
