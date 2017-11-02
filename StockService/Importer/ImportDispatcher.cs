using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using StockService.Messaging;
using StockService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockService.Importer
{
    public class ImportDispatcher
    {
        private readonly MessageWriter _messageWriter;

        public ImportDispatcher(MessageWriter messageWriter)
        {
            this._messageWriter = messageWriter;
        }

        public void Dispatch(ImportDto importDto)
        {
            _messageWriter.Write(importDto.Payload);
        }
    }
}
