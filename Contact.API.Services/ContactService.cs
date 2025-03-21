﻿using Contact.API.Infrasturucture;
using Contact.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.API.Services
{
    public class ContactService : IContactService
    {
        public static List<ContactModel> AllContacts { get; set; } = new List<ContactModel>
        {
            new ContactModel
            {
                Id=1,
                Firstname="Aysel",
                Lastname="Eliyeva"
            },
            new ContactModel
            {
                Id=2,
                Firstname="Tural",
                Lastname="Memmedov"
            },
            new ContactModel
            {
                Id=3,
                Firstname="Leyla",
                Lastname="Esgerli"
            },
        };

        public ContactModel? Add(ContactModel model)
        {
            model.Id = new Random().Next(1, 100000);
            AllContacts.Add(model);
            return model;
        }

        public bool Delete(int id)
        {
            var item=AllContacts.FirstOrDefault(c=>c.Id==id);
            if (item != null)
            {
                AllContacts.Remove(item);
            }
            return false;
        }

        public List<ContactModel> GetAll()
        {
            return AllContacts;
        }

        public ContactModel GetContactById(int id)
        {
            return AllContacts.FirstOrDefault(a => a.Id == id);
        }

        public ContactModel? Update(int id, ContactModel model)
        {
            var contact = GetContactById(id);
            if (contact != null)
            {
                contact.Firstname= model.Firstname;
                contact.Lastname= model.Lastname;
            }
            return contact;
        }
    }
}
