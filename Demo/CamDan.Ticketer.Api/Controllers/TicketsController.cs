using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CamDan.Ticketer.Api.Controllers
{
    public class TicketsController : ApiController
    {
        private static ConcurrentDictionary<int, Ticket> _data = new ConcurrentDictionary<int, Ticket>();

        static TicketsController()
        {
            if (_data.Count == 0)
            {
                _data.TryAdd(1, new Ticket(1, "Example Ticket #1"));
                _data.TryAdd(2, new Ticket(2, "Example Ticket #2"));
                _data.TryAdd(3, new Ticket(3, "Example Ticket #3"));
            }
        }

        // GET: api/Tickets
        public IEnumerable<Ticket> Get()
        {
            return _data.Select(d => d.Value).ToArray();
        }

        // GET: api/Tickets/5
        public Ticket Get(int id)
        {
            return _data[id];
        }

        // POST: api/Tickets
        public Ticket Post([FromBody]string name)
        {
            int id = _data.Count == 0 ? 0 : _data.Max(i => i.Key);

            int j = 0;
            Ticket ticket = null;
            do
            {
                if (j == 10)
                {
                    throw new InvalidOperationException("Failed to add item to Dictionary. No valid Id found after 10 tries.");
                }

                id++;
                j++;
                ticket = new Ticket(id, name);
                Trace.WriteLine($"TicketsController.Post: data.TryAdd({ticket.Id}, {ticket})");
            } while (!_data.TryAdd(ticket.Id, ticket));

            return ticket;
        }

        // PUT: api/Tickets/5
        public Ticket Put(int id, [FromBody]string value)
        {
            var ticket = _data[id];
            var updatedTicket = new Ticket(id, value);

            if (!_data.TryUpdate(id, updatedTicket, ticket))
            {
                throw new InvalidOperationException($"Failed to update Ticket. Existing value = {ticket}, new value = {updatedTicket}.");
            }

            return updatedTicket;
        }

        // DELETE: api/Tickets/5
        public void Delete(int id)
        {
            Ticket ticket = null;

            if (!_data.TryRemove(id, out ticket))
            {
                throw new InvalidOperationException($"Failed to delete Ticket with id = {id}.");
            }
        }
    }

    public class Ticket
    {
        public Ticket(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} (Id = {Id}, Name = {Name})";
        }
    }

}
