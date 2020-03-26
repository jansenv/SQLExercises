﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WalkinTheDog.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int NeighborhoodId { get; set; }
    }
}
