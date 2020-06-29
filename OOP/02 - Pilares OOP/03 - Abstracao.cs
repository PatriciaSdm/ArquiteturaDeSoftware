namespace OOP
{
    // Abstração = superclasse -> classe que será base para outras classes
    // Cada classe que herda, faz sua especialização
    // Classe abstrata só pode ser herdada, nunca instanciada
    public abstract class Eletrodomestico
    {
        private readonly string _nome;
        private readonly int _voltagem;
        protected Eletrodomestico(string nome, int voltagem)
        {
            _nome = nome;
            _voltagem = voltagem;
        }

        // MÉTODO ABSTRATO = Não é obrigatório implementar
                        // = Obrigatório sobrescrever
        // MÉTODO VIRTUAL = Obrigatório implementar
                       // = Não é obrigatório sobrescrever
        public abstract void Ligar();
        public abstract void Desligar();

        public virtual void Testar()
        {
            // teste do equipamento
        }
    }
}