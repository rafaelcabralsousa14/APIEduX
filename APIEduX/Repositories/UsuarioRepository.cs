using APIEduX.Contexts;
using APIEduX.Domains;
using APIEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Repositories
{
    public class UsuarioRepository : iUsuario
    {
        private readonly APIEduXContext _ctx;
        public UsuarioRepository()
        {
            _ctx = new APIEduXContext();
        }

        public void Adicionar(Usuarios usuario)
        {
            try
            {
                _ctx.Usuarios.Add(usuario);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public Usuarios BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Usuarios.FirstOrDefault(c => c.IdUsuario == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Usuarios usuario)
        {
            try
            {
                Usuarios usuarioTemp = BuscarPorId(usuario.IdUsuario);

                if (usuarioTemp == null)
                    throw new Exception("Usuário não encontrado");

                usuarioTemp.Nome = usuario.Nome;
                usuarioTemp.Senha = usuario.Senha;
                usuarioTemp.Email = usuario.Email;
                usuarioTemp.DataCadastro = usuario.DataCadastro;
                usuarioTemp.DataUltimoAcesso = usuario.DataUltimoAcesso;

                _ctx.Usuarios.Update(usuarioTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Usuarios> Listar()
        {
            try
            {
                return _ctx.Usuarios.ToList();
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
                Usuarios usuarioTemp = BuscarPorId(id);

                if (usuarioTemp == null)
                    throw new Exception("Usuário não encontrado");

                _ctx.Usuarios.Remove(usuarioTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
