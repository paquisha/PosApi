using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infraestructure.Persistences.Contexts;
using POS.Infraestructure.Persistences.Interfaces;

namespace POS.Infraestructure.Persistences.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly PosContext _context;

        public UserRepository(PosContext context) : base(context)
        {
            _context = context;
        }
        public async Task<User> AccountByUserName(string userName)
        {
            try
            {
                var account = await _context.Users.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.UserName!.Equals(userName));
                return account!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
