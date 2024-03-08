using CaseForForceget.DataAccessLayer.Abstract;
using CaseForForceget.DataAccessLayer.Context;
using CaseForForceget.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseForForceget.DataAccessLayer.EntityFramework
{
    public class EfOfferDal : GenericDal<Offer>, IOfferDal
    {
        private readonly DbContextForceget _db;
        public EfOfferDal(DbContextForceget dbContextForceget) : base(dbContextForceget)
        {
            _db = dbContextForceget;
        }
    }
}
