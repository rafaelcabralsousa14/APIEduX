using APIEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Interfaces
{
    interface iUsuario
    {
        List<Usuarios> Listar();
        Usuarios BuscarPorId(Guid id);
        void Adicionar(Usuarios usuario);
        void Remover(Guid id);
        void Editar(Usuarios usuario);
    }
}
