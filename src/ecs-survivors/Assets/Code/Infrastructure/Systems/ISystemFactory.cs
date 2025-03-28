using Entitas;

namespace Code.Infrastructure.Systems
{
    public interface ISystemFactory
    {
        public T Create<T>() where T : ISystem;
        public T Create<T>(params object[] argus) where T : ISystem;
    }
}