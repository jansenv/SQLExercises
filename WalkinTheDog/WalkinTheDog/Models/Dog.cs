﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WalkinTheDog.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Notes { get; set; }
        public int OwnerId { get; set; }
    }
}