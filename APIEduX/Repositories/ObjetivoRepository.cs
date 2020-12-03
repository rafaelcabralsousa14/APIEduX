using APIEduX.Contexts;
using APIEduX.Domains;
using APIEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Repositories
{
    public class ObjetivoRepository : iObjetivo
    {
        private readonly APIEduXContext _ctx;

        public ObjetivoRepository()
        {
            _ctx = new APIEduXContext();
        }

        public void Adicionar(Objetivos objetivo)
        {
            try
            {
                _ctx.Objetivos.Add(objetivo);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Objetivos BuscarPorId(Guid id)
        {
            try
            {
                Objetivos objetivo = _ctx.Objetivos.Find(id);

                return objetivo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Objetivos objetivo)
        {
            try
            {
                Objetivos objetivoTemp = BuscarPorId(objetivo.IdObjetivo);

                if (objetivoTemp == null)
                    throw new Exception("Objetivo não encontrado");

                objetivoTemp.Descricao = objetivo.Descricao;
                _ctx.Objetivos.Update(objetivoTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Objetivos> Listar()
        {
            try
            {
                List<Objetivos> objetivos = _ctx.Objetivos.ToList();

                return objetivos;
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
                Objetivos objetivo = BuscarPorId(id);

                if (objetivo == null)
                    throw new Exception("Objetivo não encontrado");

                _ctx.Objetivos.Remove(objetivo);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
