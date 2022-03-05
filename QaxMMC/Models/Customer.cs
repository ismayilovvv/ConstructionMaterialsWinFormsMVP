﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaxMMC.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string RegisterAddress { get; set; }
        public string BornAddress { get; set; }
        public string PassportSeriaNumber { get; set; }
        public string PassportFIN { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Company { get; set; }
        public string CompanyAddress { get; set; }
        public string VOEN { get; set; }
        public string Bank { get; set; }
        public string AccountNumber { get; set; }
        public string Account { get; set; }
        public string Code { get; set; }
        public string Swift { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
