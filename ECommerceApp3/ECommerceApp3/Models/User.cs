﻿using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ECommerceApp3.Models
{
    public class User
    {
        [PrimaryKey]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CompanyId { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsUser { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsSupplier { get; set; }

        public bool IsRemembered { get; set; }

        public string Password { get; set; }


        //apenas leitura
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public string PhotoFullPath { get { return string.Format("http://zulu-software.com/ECommerce{0}", Photo.Substring(1)); } }

        [ManyToOne]
        public Company Company { get; set; }

        public override int GetHashCode()
        {
            return UserId;
        }
    }
}
