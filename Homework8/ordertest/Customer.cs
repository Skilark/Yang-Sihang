﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest
{

    public class Customer {


        public uint Id { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }

        public Customer() { }

        public Customer(uint id, string name, string phonenumber)
        {
            this.Id = id;
            this.Name = name;
            this.PhoneNum = phonenumber;
        }


        public override string ToString()
        {
            return Name;
        }


    }
}
