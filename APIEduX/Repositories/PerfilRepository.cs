using APIEduX.Contexts;
using APIEduX.Domains;
using APIEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Repositories
{
    public class PerfilRepository : iPerfil
    {
        private readonly APIEduXContext _ctx;

        public PerfilRepository()
        {
            _ctx = new APIEduXContext();
        }

        public void Adicionar(Perfis perfil)
        {
            try
            {
                _ctx.Perfis.Add(perfil);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Perfis BuscarPorId(Guid id)
        {
            try
            {
                Perfis perfil = _ctx.Perfis.Find(id);

                return perfil;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Perfis perfil)
        {
            try
            {
                Perfis perfilTemp = BuscarPorId(perfil.IdPerfil);

                if (perfilTemp == null)
                    throw new Exception("Perfil não encontrado");

                perfilTemp.Permissao = perfil.Permissao;
                _ctx.Perfis.Update(perfilTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Perfis> Listar()
        {
            try
            {
                List<Perfis> perfils = _ctx.Perfis.ToList();

                return perfils;
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
                Perfis perfil = BuscarPorId(id);

                if (perfil == null)
                    throw new Exception("Perfil não encontrado");

                _ctx.Perfis.Remove(perfil);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
