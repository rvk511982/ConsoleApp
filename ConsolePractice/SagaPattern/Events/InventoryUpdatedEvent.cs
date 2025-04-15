﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.SagaPattern.Events
{
    public class InventoryUpdatedEvent : CommonEvents
    {
        public bool IsStockAvailable { get; set; }
    }
}
