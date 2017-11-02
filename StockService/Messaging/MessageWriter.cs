using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Messaging
{
    public interface MessageWriter
    {
        void Write(String message);
    }
}
