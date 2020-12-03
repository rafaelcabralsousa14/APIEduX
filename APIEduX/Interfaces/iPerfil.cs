using APIEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Interfaces
{
    interface iPerfil
    {
        List<Perfis> Listar();
        Perfis BuscarPorId(Guid id);
        void Adicionar(Perfis perfil);
        void Remover(Guid id);
        void Editar(Perfis perfil);
    }
}
