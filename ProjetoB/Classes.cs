using ProjetoA;

namespace ProjetoB
{
    class TesteClasses
    {
        public TesteClasses()
        {
            var publica = new Publica();
            //var privada = new Privada();          //Não esta no mesmo assembly
            //var interna = new Interna();          //Não esta no mesmo assembly
            //var abstrata = new Abstrata();
        }
    }

    class TesteModificador1
    {
        public TesteModificador1()
        {
            var publica = new Publica();

            publica.TestePublico();
            //publica.TesteInternal();             //Não esta no mesmo assembly
            //publica.TesteProtegidoInterno();     //Não esta no mesmo assembly nem possui herança
            //publica.TesteProtegido();            //Não possui herança
            //publica.TestePrivadoProtegido();     //Não esta no mesmo assembly nem possui herança
            //publica.TestePrivado();              //Somente a própria classe pode acessar
        }
    }

    class TesteModificador2 : Publica
    {
        public TesteModificador2()
        {
            TestePublico();
            TesteProtegido();
            TesteProtegidoInterno();
            //TesteInternal();
            //TestePrivadoProtegido();
            //TestePrivado();
        }
    }
}


