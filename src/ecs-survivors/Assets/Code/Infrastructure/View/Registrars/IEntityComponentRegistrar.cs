namespace Code.Infrastructure.View.Registrars
{
    public interface IEntityComponentRegistrar
    {
        void RegisterComponent();
        void UnregisterComponent();
    }
}