using APIEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Interfaces
{
    interface iTurma
    {
        List<Turmas> Listar();
        Turmas BuscarPorId(Guid id);
        void Adicionar(Turmas turma);
        void Remover(Guid id);
        void Editar(Turmas turma);
    }
}
