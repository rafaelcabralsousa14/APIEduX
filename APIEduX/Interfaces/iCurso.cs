using APIEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Interfaces
{
    interface iCurso
    {
        List<Cursos> Listar();
        Cursos BuscarPorId(Guid id);
        void Adicionar(Cursos curso);
        void Remover(Guid id);
        void Editar(Cursos curso);
    }
}
