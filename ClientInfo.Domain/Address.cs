using ClientInfo.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientInfo.Domain
{
    public class Address
    {
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Uf Uf { get; set; }
    }
}
