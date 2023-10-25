using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Aptidao_UGB.Model.Interfaces
{
    public interface InterfaceModel<T> where T : class
    {

        //metodos sincronos
        T Incluir(T obj);
        T Alterar(T obj);
        T SelecionarPk(params object[] variavel);
        List<T> SelecionarTodos();
        void Excluir(T obj);
        void Excluir(params object[] variavel);


        //metodos asincronos

        Task<T> IncluirAsync(T obj);
        Task<T> AlterarAsync(T obj);
        Task<T> SelecionarPkAsync(params object[] variavel);
        Task<List<T>> SelecionarTodosAsync();
        Task ExcluirAsync(T obj);
        Task ExcluirAsync(params object[] variavel);



    }
}