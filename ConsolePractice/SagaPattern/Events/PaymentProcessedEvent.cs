using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.SagaPattern.Events
{
    public class PaymentProcessedEvent : CommonEvents
    {
        public bool IsSuccessful { get; set; }
    }
}
