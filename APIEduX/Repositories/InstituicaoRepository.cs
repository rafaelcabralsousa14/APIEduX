using APIEduX.Contexts;
using APIEduX.Domains;
using APIEduX.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEduX.Repositories
{
    public class InstituicaoRepository : iInstituicao
    {
        private readonly APIEduXContext _ctx;
        public InstituicaoRepository()
        {
            _ctx = new APIEduXContext();
        }

        public void Adicionar(Instituicoes instituicao)
        {
            try
            {
                _ctx.Instituicoes.Add(instituicao);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public Instituicoes BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Instituicoes.FirstOrDefault(c => c.IdInstituicao == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Instituicoes instituicao)
        {
            try
            {
                Instituicoes instituicaTemp = BuscarPorId(instituicao.IdInstituicao);

                if (instituicaTemp == null)
                    throw new Exception("Instituição não encontrada");

                instituicaTemp.Nome = instituicao.Nome;
                instituicaTemp.Logradouro = instituicao.Logradouro;
                instituicaTemp.Numero = instituicao.Numero;
                instituicaTemp.Complemento = instituicao.Complemento;
                instituicaTemp.Bairro = instituicao.Bairro;
                instituicaTemp.Cidade = instituicao.Cidade;
                instituicaTemp.Uf = instituicao.Uf;
                instituicaTemp.Cep = instituicao.Cep;

                _ctx.Instituicoes.Update(instituicaTemp);
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Instituicoes> Listar()
        {
            try
            {
                return _ctx.Instituicoes.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                Instituicoes instituicaTemp = BuscarPorId(id);

                if (instituicaTemp == null)
                    throw new Exception("Instituição não encontrada");

                _ctx.Instituicoes.Remove(instituicaTemp);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
