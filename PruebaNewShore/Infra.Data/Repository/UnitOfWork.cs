using Domain.Interfaces;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PruebaNewShoreDBContext _ctx;
        public IRepository<Journey> JourneyRepository => new BaseRepository<Journey>(_ctx);
        public IRepository<JourneyFlight> JourneyFlightRepository => new BaseRepository<JourneyFlight>(_ctx);
        public IRepository<Fligth> FlightRepository => new BaseRepository<Fligth>(_ctx);
        public IRepository<Transport> TransportRepository => new BaseRepository<Transport>(_ctx);
        public IRepository<Role> RoleRepository => new BaseRepository<Role>(_ctx);
        public IRepository<User> UserRepository => new BaseRepository<User>(_ctx);

        public UnitOfWork(PruebaNewShoreDBContext ctx)
        {
            _ctx = ctx;

        }

        public string GetDbConnection()
        {
            return _ctx.Database.GetDbConnection().ConnectionString;
        }


        public void Dispose()
        {
            if (_ctx != null)
            {
                _ctx.Dispose();
            }
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }

    }
}
