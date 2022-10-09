﻿using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.AddAddress
{
    public class AddUserAddressCommand : IBaseCommand
    {
        public AddUserAddressCommand(Guid userId, string shire, string city, string postalCode, string postalAddress, PhoneNumber phoneNumber, string nationalCode, string fullName)
        {
            UserId = userId;
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            NationalCode = nationalCode;
            FullName = fullName;
        }
        public Guid UserId { get; set; }
        public string Shire { get; private set; }
        public string City { get; private set; }
        public string PostalCode { get; private set; }
        public string PostalAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public string FullName { get; private set; }
        public string NationalCode { get; private set; }

    }
}
