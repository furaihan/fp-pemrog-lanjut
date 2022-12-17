﻿using System;

namespace PinusPengger.Model
{
    internal class History
    {
        public int? HisID { get; set; }
        public string ResCode { get; set; }
        public DateTime? ResCheckIn { get; set; }
        public DateTime? ResCheckOut { get; set; }
        public int? ResIDCust { get; set; }
        public int? ResIDRoom { get; set; }
    }
}
