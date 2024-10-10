using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;

namespace HotelProject.BusinessLayer.Concrete
{
    public class SendMessageManager : ISendMessageService
    {
        private readonly ISendMessageDal _sendMessageDal;

        public SendMessageManager(ISendMessageDal sendMessageDal)
        {
            _sendMessageDal = sendMessageDal;
        }

        public void TDelete(SendMessage entity)
        {
            _sendMessageDal.Delete(entity);
        }

        public SendMessage TGetById(int id)
        {
            return _sendMessageDal.GetById(id);
        }

        public List<SendMessage> TGetList()
        {
            return _sendMessageDal.GetList();
        }

        public void TInsert(SendMessage entity)
        {
            _sendMessageDal.Insert(entity);
        }

        public int TSendMessageCount()
        {
            return _sendMessageDal.SendMessageCount();
        }

        public void TUpdate(SendMessage entity)
        {
            _sendMessageDal.Update(entity);
        }
    }
}
