using System.Runtime.CompilerServices;

//[assembly: InternalsVisibleTo("ProjetoB")] // Para deixar visível ao ProjetoB - (Como se estivesse no mesmo assembly)
//[assembly: InternalsVisibleTo("ProjetoB")] // Para deixar visível ao ProjetoB - (Como se estivesse no mesmo assembly)
namespace ProjetoA
{
    #region Classes

    public class Publica
    {
        public void TestePublico() { }
        private void TestePrivado() { }
        internal void TesteInternal() { }
        protected void TesteProtegido() { }
        private protected void TestePrivadoProtegido() { }  // Deve ser Privado E protegido
        protected internal void TesteProtegidoInterno() { } // Deve ser Interno OU protegido
    }

    public sealed class Selada { } //sealed = não pode ser herdada, apenas instanciada

    class Privada { }

    internal class Interna { }

    abstract class Abstrata { }

    #endregion
    
    #region Testes

    class TesteClasses
    {
        public TesteClasses()
        {
            var publica = new Publica();
            var privada = new Privada();  //Possivel instanciar pois esta no mesmo assembly
            var interna = new Interna();  //""
            //var abstrata = new Abstrata(); //Classe abstrata não pode ser instanciada
        }
    }

    //class TesteSelada : Selada { }  // Não pode herdar, pois é uma sealed class

    class TesteModificador1
    {
        public TesteModificador1()
        {
            var publica = new Publica();

            publica.TestePublico();
            publica.TesteInternal(); //Possivel chamar pois esta no mesmo assembly
            publica.TesteProtegidoInterno();
            //publica.TesteProtegido(); // Não pode chamar pois não esta herdando de  "Publica()" =>  EX: TesteModificador2()
            //publica.TestePrivado();  // Método privado só pode ser chamado internamente na classe "Publica()"
            //publica.TestePrivadoProtegido();  // "", ""
        }
    }

    class TesteModificador2 : Publica
    {
        public TesteModificador2()
        {
            TestePublico();
            TesteInternal();
            TesteProtegido();
            TesteProtegidoInterno(); // Possivel pois esta herdando
            TestePrivadoProtegido(); //""
            //TestePrivado();
        }
    }

    #endregion
}

/*******************************************************/
// public:

// Access is not restricted.
/*******************************************************/
// protected:

// Access is limited to the containing class or types
// derived from the containing class.
/*******************************************************/
// internal:

// Access is limited to the current assembly.               // CURRENT ASSEMBLY = DLL (ao compilar) = todas as classes dentro do projeto
/*******************************************************/
// protected internal:

// Access is limited to the current assembly or types       // CURRENT ASSEMBLY = DLL (ao compilar) = todas as classes dentro do projeto
// derived from the containing class.
/*******************************************************/
// private:

// Access is limited to the containing type.
/*******************************************************/
// private protected:

// Access is limited to the containing class or types
// derived from the containing class within the current
// assembly.Available since C# 7.2.
/*******************************************************/
