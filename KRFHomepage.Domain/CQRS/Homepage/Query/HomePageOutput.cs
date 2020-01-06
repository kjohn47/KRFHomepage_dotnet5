﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KRFHomepage.Domain.CQRS.Homepage.Query
{
    public class HomePageOutput
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }

        public string UserData { get; set; }
    }
}
