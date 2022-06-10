﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week17.Domain
{
    public class Address
    {

        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int HomeNumber { get; set; }

        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
