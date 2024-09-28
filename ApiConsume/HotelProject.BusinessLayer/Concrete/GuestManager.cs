using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class GuestManager : IGuestService
    {
        private readonly IGuestDal _guestDal;
        public GuestManager(IGuestDal guestDal)
        {
            //kodun test edilebilir olması için bağımlılıklarını constructor üzerinden enjekte ediyoruz.Burasi ise kodun calimasini garanti altina almak icin yazilmistir.
            _guestDal = guestDal ?? throw new ArgumentNullException(nameof(guestDal));
        }
        public void TDelete(Guest entity)
        {
            _guestDal.Delete(entity);
        }

        public Guest TGetById(int id)
        {
            return _guestDal.GetById(id);
        }

        public void TInsert(Guest entity)
        {
            _guestDal.Insert(entity);
        }

        public void TUpdate(Guest entity)
        {
            _guestDal.Update(entity);
        }

        public List<Guest> TGetList()
        {
            return _guestDal.GetList();
        }
    }
}
