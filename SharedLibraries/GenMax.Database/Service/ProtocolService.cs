using GenMax.Database.DbContext;
using GenMax.Database.EntityModel;
using GenMax.Database.Interface;
using System;
using System.Collections.Generic;

namespace GenMax.Database.Service
{
    public class ProtocolService : IProtocolService
    {
        private readonly ProtocolDbContext _context;

        public ProtocolService(ProtocolDbContext context)
        {
            _context = context;
        }

        public List<Protocol> GetProtocols()
        {
            throw new NotImplementedException();
        }
    }
}
