using APIEduX.Contexts;
using APIEduX.Domains;
using APIEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Repositories
{
    public class AlunoTurmaRepository : iAlunoTurma
    {
        private readonly APIEduXContext _ctx;

        public AlunoTurmaRepository()
        {
            _ctx = new APIEduXContext();
        }

        public void Adicionar(AlunoTurmas alunoTurma)
        {
            try
            {
                _ctx.AlunoTurmas.Add(alunoTurma);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public AlunoTurmas BuscarPorId(Guid id)
        {
            try
            {
                AlunoTurmas alunosTurmas = _ctx.AlunoTurmas.Find(id);

                return alunosTurmas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(AlunoTurmas alunoTurma)
        {
            try
            {
                AlunoTurmas alunoTurmaTemp = BuscarPorId(alunoTurma.IdAlunoTurma);

                if (alunoTurmaTemp == null)
                    throw new Exception("Aluno não encontrado");

                alunoTurmaTemp.IdUsuario = alunoTurma.IdUsuario;
                alunoTurmaTemp.IdTurma = alunoTurma.IdTurma;

                _ctx.AlunoTurmas.Update(alunoTurmaTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<AlunoTurmas> Listar()
        {
            try
            {
                List<AlunoTurmas> alunosTurmas = _ctx.AlunoTurmas.ToList();

                return alunosTurmas;
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
                AlunoTurmas alunoTurma = BuscarPorId(id);

                if (alunoTurma == null)
                    throw new Exception("Aluno não encontrado");

                _ctx.AlunoTurmas.Remove(alunoTurma);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
