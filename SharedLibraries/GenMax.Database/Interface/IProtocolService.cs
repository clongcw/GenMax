using GenMax.Database.EntityModel;
using System.Collections.Generic;

namespace GenMax.Database.Interface
{
    public interface IProtocolService
    {
        List<Protocol> GetProtocols();
    }
}
