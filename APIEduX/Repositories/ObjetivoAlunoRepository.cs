using APIEduX.Contexts;
using APIEduX.Domains;
using APIEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Repositories
{
    public class ObjetivoAlunoRepository : iObjetivoAluno
    {
        private readonly APIEduXContext _ctx;

        public ObjetivoAlunoRepository()
        {
            _ctx = new APIEduXContext();
        }

        public void Adicionar(ObjetivoAlunos objetivoaluno)
        {
            try
            {
                _ctx.ObjetivoAlunos.Add(objetivoaluno);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ObjetivoAlunos BuscarPorId(Guid id)
        {
            try
            {

                ObjetivoAlunos objetivoaluno = _ctx.ObjetivoAlunos.Find(id);

                return objetivoaluno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(ObjetivoAlunos objetivoaluno)
        {
            try
            {
                ObjetivoAlunos objetivoalunotemp = BuscarPorId(objetivoaluno.IdObjetivoAluno);

                if (objetivoalunotemp == null)
                    throw new Exception("Objetivo não encontrado");

                objetivoalunotemp.Nota = objetivoaluno.Nota;
                objetivoalunotemp.DataEntrega = objetivoaluno.DataEntrega;

                _ctx.ObjetivoAlunos.Update(objetivoalunotemp);
                _ctx.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ObjetivoAlunos> Listar()
        {
            try
            {
                return _ctx.ObjetivoAlunos.ToList();
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
                ObjetivoAlunos objetivoaluno = BuscarPorId(id);

                if (objetivoaluno == null)
                    throw new Exception("Objetivo não encontrado");

                _ctx.ObjetivoAlunos.Remove(objetivoaluno);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

