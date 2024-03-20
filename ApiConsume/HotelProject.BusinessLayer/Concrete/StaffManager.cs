using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.BusinessLayer.Concrete
{
    public class StaffManager : IStaffService
    {
        private readonly IStaffService _staffService;

        public StaffManager(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public void TDelete(Staff entity)
        {
            _staffService.TDelete(entity);
        }

        public Staff TGetById(int id)
        {
            return _staffService.TGetById(id);
        }

        public List<Staff> TGetList()
        {
            return _staffService.TGetList();
        }

        public void TInsert(Staff entity)
        {
            _staffService.TInsert(entity);
        }

        public void TUpdate(Staff entity)
        {
            _staffService.TUpdate(entity);
        }
    }
}
