using APIEduX.Contexts;
using APIEduX.Domains;
using APIEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Repositories
{
    public class CurtidaRepository : iCurtida
    {
        private readonly APIEduXContext _ctx;

        public CurtidaRepository()
        {
            _ctx = new APIEduXContext();
        }

        public void Adicionar(Curtidas curtida)
        {
            try
            {
                _ctx.Curtidas.Add(curtida);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Curtidas BuscarPorId(Guid id)
        {
            try
            {
                Curtidas curtida = _ctx.Curtidas.Find(id);

                return curtida;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Curtidas> Listar()
        {
            try
            {
                List<Curtidas> curtidas = _ctx.Curtidas.ToList();

                return curtidas;
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
                Curtidas curtida = BuscarPorId(id);

                if (curtida == null)
                    throw new Exception("Curtida não encontrado");

                _ctx.Curtidas.Remove(curtida);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
