﻿using System;
using System.Collections.Generic;

namespace EntityFrameCoreReharsearsal.Model
{
    public class Battle
    {
        public Battle()
        {
            SamuraiBattle = new List<SamuraiBattle>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SamuraiBattle> SamuraiBattle { get; set; }
    }
}