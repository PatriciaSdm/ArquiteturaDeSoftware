
namespace OOP
{
    public class AutomacaoCafe
    {
        // Encapsulamento = Encapsular comportamentos através da exposição de métodos publicos/privados
        //                  Esconder certos métodos (comportamentos), atráves de métodos privados, 
        //                  para expor outro de alto nível que faça uso deles (privados)
        //                  Ex: PrepararCafe (Testar(), AquecerAgua(), MoerGraos())
        public void ServirCafe()
        {
            var espresso = new CafeteiraEspressa();
            espresso.Ligar();
            espresso.PrepararCafe();
            espresso.Desligar();
        }
    }
}