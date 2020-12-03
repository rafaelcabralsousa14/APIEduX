using APIEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Interfaces
{
    interface iAlunoTurma
    {
        List<AlunoTurmas> Listar();
        AlunoTurmas BuscarPorId(Guid id);
        void Adicionar(AlunoTurmas alunoTurma);
        void Remover(Guid id);
        void Editar(AlunoTurmas alunoTurma);
    }
}
