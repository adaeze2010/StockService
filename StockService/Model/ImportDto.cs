using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockService.Model
{
    public class ImportDto
    {
        private string _payload;

        public string Payload
        {
            get { return _payload; }
            set { _payload = value; }
        }

    }
}
