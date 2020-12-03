using APIEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Interfaces
{
    interface iInstituicao
    {
        List<Instituicoes> Listar();
        Instituicoes BuscarPorId(Guid id);
        void Adicionar(Instituicoes instituicao);
        void Remover(Guid id);
        void Editar(Instituicoes instituicao);
    }
}
