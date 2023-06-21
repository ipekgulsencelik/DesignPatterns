using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDAL _customerDAL;
        private readonly IUnitOfWorkDAL _unitOfWorkDAL;

        public CustomerManager(ICustomerDAL customerDAL, IUnitOfWorkDAL unitOfWorkDAL)
        {
            _customerDAL = customerDAL;
            _unitOfWorkDAL = unitOfWorkDAL;
        }

        public void TDelete(Customer entity)
        {
            _customerDAL.Delete(entity);
            _unitOfWorkDAL.Save();
        }

        public Customer TGetByID(int id)
        {
            return _customerDAL.GetByID(id);
        }

        public List<Customer> TGetList()
        {
            return _customerDAL.GetList();
        }

        public void TInsert(Customer entity)
        {
            _customerDAL.Insert(entity);
            _unitOfWorkDAL.Save();
        }

        public void TMultiUpdate(List<Customer> entity)
        {
            _customerDAL.MultiUpdate(entity);
            _unitOfWorkDAL.Save();
        }

        public void TUpdate(Customer entity)
        {
            _customerDAL.Update(entity);
            _unitOfWorkDAL.Save();
        }
    }
}
