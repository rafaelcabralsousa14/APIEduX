using APIEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Interfaces
{
    interface iCategoria
    {
        List<Categorias> Listar();
        Categorias BuscarPorId(Guid id);
        void Adicionar(Categorias categoria);
        void Remover(Guid id);
        void Editar(Categorias categoria);
    }
}
