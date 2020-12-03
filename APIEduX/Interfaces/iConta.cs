using APIEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Interfaces
{
    public interface iConta
    {
        Usuarios Login(string email, string senha);

        Usuarios Register(string nome, string email, string senha, string tipo);
    }
}
