using POS.Infraestructure.Commons.Base.Request;

namespace POS.Infraestructure.Helpers
{
    public static class QueryableHelper
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, BasePaginationRequest request)
        {
            return queryable.Skip(count: (request.NumPage - 1) * request.Records).Take(count: request.Records);

        }
    }
}
