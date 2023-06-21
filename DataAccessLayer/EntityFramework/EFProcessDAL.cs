using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EFProcessDAL : GenericRepository<Process>, IProcessDAL
    {
        public EFProcessDAL(Context context) : base(context)
        {

        }
    }
}
