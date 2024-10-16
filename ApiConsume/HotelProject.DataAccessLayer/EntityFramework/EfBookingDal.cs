﻿using HotelProject.DataAccessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.DataAccessLayer.Repositories;
using HotelProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(Context context) : base(context)
        {
        }

        public void BookingStatusChangedApproved(Booking booking)
        {
            var context = new Context();
            var values =context.Bookings.Where(x => x.BookingId == booking.BookingId).FirstOrDefault().Status = "Onaylandi";
            context.SaveChanges();
        }
        public void BookingStatusChangedCanceled(Booking booking)
        {
            var context = new Context();
            var values = context.Bookings.Where(x => x.BookingId == booking.BookingId).FirstOrDefault().Status = "Iptal";
            context.SaveChanges();
        }
        public void BookingStatusChangedWaiting(Booking booking)
        {
            var context = new Context();
            var values = context.Bookings.Where(x => x.BookingId == booking.BookingId).FirstOrDefault().Status = "Beklemede";
            context.SaveChanges();
        }
        public void BookingStatusChangedCompleted(Booking booking)
        {
            var context = new Context();
            var values = context.Bookings.Where(x => x.BookingId == booking.BookingId).FirstOrDefault().Status = "Tamamlandi";
            context.SaveChanges();
        }
        public void BookingStatusChangedApprovedId(int id)
        {
            var context = new Context();
            var values = context.Bookings.Find(id);
            values.Status = "Onaylandi";
            context.SaveChanges();
        }
    }
}
