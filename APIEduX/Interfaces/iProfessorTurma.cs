using APIEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Interfaces
{
    interface iProfessorTurma
    {
        List<ProfessorTurmas> Listar();
        ProfessorTurmas BuscarPorId(Guid id);
        void Adicionar(ProfessorTurmas professorTurma);
        void Remover(Guid id);
        void Editar(ProfessorTurmas professorTurma);
    }
}
