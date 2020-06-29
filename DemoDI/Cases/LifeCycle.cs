using System;

namespace DemoDI.Cases
{
    public class OperacaoService
    {
        public OperacaoService(
            IOperacaoTransient transient,
            IOperacaoScoped scoped,
            IOperacaoSingleton singleton,
            IOperacaoSingletonInstance singletonInstance)
        {
            Transient = transient;     //Muda em todos os lugares (instancias), mesmo durante o mesmo request
            Scoped = scoped;           //Se mantem o mesmo em todos os lugares durante o mesmo request, (muda de usuário p/ usuário)
            Singleton = singleton;     //Se mantem o mesmo independente do request, durante toda execução da aplicação
            SingletonInstance = singletonInstance;  //""Igual o Singleton, porém é definido a instancia (EX: services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));)
        }

        public IOperacaoTransient Transient { get; }
        public IOperacaoScoped Scoped { get; }
        public IOperacaoSingleton Singleton { get; }
        public IOperacaoSingletonInstance SingletonInstance { get; }
    }

    public class Operacao : IOperacaoTransient,
        IOperacaoScoped,
        IOperacaoSingleton,
        IOperacaoSingletonInstance
    {
        public Operacao() : this(Guid.NewGuid())
        {
        }

        public Operacao(Guid id)
        {
            OperacaoId = id;
        }

        public Guid OperacaoId { get; private set; }
    }

    public interface IOperacao
    {
        Guid OperacaoId { get; }
    }

    public interface IOperacaoTransient : IOperacao
    {
    }

    public interface IOperacaoScoped : IOperacao
    {
    }

    public interface IOperacaoSingleton : IOperacao
    {
    }

    public interface IOperacaoSingletonInstance : IOperacao
    {
    }
}