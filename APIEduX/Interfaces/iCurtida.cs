using APIEduX.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Interfaces
{
    interface iCurtida
    {
        List<Curtidas> Listar();
        Curtidas BuscarPorId(Guid id);
        void Adicionar(Curtidas curtida);
        void Remover(Guid id);
    }
}
