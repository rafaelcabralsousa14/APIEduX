using APIEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Interfaces
{
    interface iObjetivoAluno
    {
        List<ObjetivoAlunos> Listar();
        ObjetivoAlunos BuscarPorId(Guid id);
        void Adicionar(ObjetivoAlunos objetivoAluno);
        void Remover(Guid id);
        void Editar(ObjetivoAlunos objetivoAluno);
    }
}
