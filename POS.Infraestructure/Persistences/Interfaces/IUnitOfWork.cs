namespace POS.Infraestructure.Persistences.Interfaces
{
    public interface IUnitOfWork
    {
        //declaramos nuestras interfaces a nivel de repositorio
        //IPurposeRepository Purpose { get; }
        IPersonaRepository Persona { get; }
        IUserRepository User { get; }
        void SaveChanges();
        void SaveChangesAsync();
    }
}
