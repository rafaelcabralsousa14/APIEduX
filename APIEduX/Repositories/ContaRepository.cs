using APIEduX.Contexts;
using APIEduX.Domains;
using APIEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Repositories
{
    public class ContaRepository : iConta
    {
        private readonly APIEduXContext _context;

        public ContaRepository(APIEduXContext context)
        {
            _context = context;
        }

        public Usuarios Login(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuarios Register(string nome, string email, string senha, string tipo)
        {
            Usuarios usuario = new Usuarios() { Nome = nome, Email = email, Senha = senha, Tipo = tipo };
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }
    }
}
