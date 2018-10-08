using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheConference.Models;

namespace TheConference.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly DataContext _db;

        public SpeakersController(DataContext dataContext)
        {
            _db = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        [HttpGet]
        public IActionResult NewBooking(int EventID)
        {
            var booking = new Booking { EventId = EventID };
            return View(booking);
        }

        [HttpPost]
        public IActionResult NewBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return View(booking);
            }
            SpeakerEvent speakerEvent = _db.Events.FirstOrDefault(x => x.Id == booking.EventId);
            lock (speakerEvent)
            {
                if(speakerEvent.RemainingTickets < booking.NumberOfTickets)
                {
                    return View(booking);
                }
                speakerEvent.RemainingTickets -= booking.NumberOfTickets;
                _db.Update(speakerEvent);
                _db.Add(booking);
                _db.SaveChanges();
            }

            return RedirectToAction("ThankYou");

        }
    }
}