using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infraestructure.Commons.Base.Request;
using POS.Infraestructure.Commons.Base.Response;
using POS.Infraestructure.Persistences.Contexts;
using POS.Infraestructure.Persistences.Interfaces;

namespace POS.Infraestructure.Persistences.Repositories
{
    public class PersonaRepository : GenericRepository<Persona>, IPersonaRepository
    {
        private readonly PosContext _context;
        public PersonaRepository(PosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BaseEntityResponse<Persona>> ListPersonasFiltered(BaseFilterRequest filters)
        {
            try
            {
                var response = new BaseEntityResponse<Persona>();

                var payment = GetEntityQuery(filter: c => c.AuditDeleteUser == null && c.AuditCreateDate == null);

                if (filters.NumFilter is not null && !string.IsNullOrEmpty(value: filters.TextFilter))
                {
                    switch (filters.NumFilter)
                    {
                        case 1:
                            payment = payment.Where(predicate: x => x.LastName!.Contains(filters.TextFilter));
                            break;
                        case 2:
                            payment = payment.Where(predicate: x => x.FirtsName!.Contains(filters.TextFilter));
                            break;
                    }
                }

                if (filters.StartDate is not null)
                {
                    payment = payment.Where(predicate: x => x.Status.Equals(filters.StateFilter));
                }

                if (!string.IsNullOrEmpty(value: filters.StartDate) && !string.IsNullOrEmpty(value: filters.EndDate))
                {
                    payment = payment.Where(predicate: x =>
                        x.AuditCreateDate >= Convert.ToDateTime(filters.StartDate) &&
                        x.AuditCreateDate <= Convert.ToDateTime(filters.EndDate).AddDays(1));
                }

                if (filters.Sort is null) filters.Sort = "Id";
                response.TotalRecords = await payment.CountAsync();
                response.Items = await Ordering(request: filters, queryable: payment, pagination: !(bool)filters.Download!).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(message: ex.Message);
            }
        }
    }
}
