using POS.Infraestructure.Persistences.Contexts;
using POS.Infraestructure.Persistences.Interfaces;

namespace POS.Infraestructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PosContext _context;
        public IUserRepository User { get; private set; }
        public IPersonaRepository Persona { get; private set; }

        //hay que inicializar la inyeccion, NO AGREGAR NADA MAS EN LOS PARENTESIS, SOLO DONTRO DEL METODO
        public UnitOfWork(PosContext context)
        {
            _context = context;
            User = new UserRepository(context: _context);
            Persona = new PersonaRepository(context: _context);
        }

        public void Dispose()
        {
            ///liberar recursos de memoria
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
