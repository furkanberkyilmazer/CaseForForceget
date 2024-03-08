using CaseForForceget.BussinesLayer.Abstract;
using CaseForForceget.DataAccess.UnitOfWork;
using CaseForForceget.DataAccessLayer.Abstract;
using CaseForForceget.EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseForForceget.BussinesLayer.Concrete
{
    public class OfferService : GenericService<Offer>, IOfferService
    {
        private readonly IOfferDal _offerDal;
        private readonly IUnitOfWork _unitofWork;
        public OfferService(IOfferDal offerDal, IUnitOfWork unitofWork) : base(offerDal, unitofWork)
        {
            _offerDal = offerDal;
            _unitofWork = unitofWork;
        }

    }
}
