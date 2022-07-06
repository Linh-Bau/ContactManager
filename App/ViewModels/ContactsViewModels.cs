﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Models;
namespace App.ViewModels
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        public BindingSource ContactBindingSource { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Load()
        {
            List<Contact> contacts;
            var formatter = new BinaryFormatter();
            if (!File.Exists("data.dat"))
            {
                contacts = new List<Contact>();
                var stream = File.Create("data.dat");
                formatter.Serialize(stream, contacts);
                stream.Close();
            }
            else
            {
                using (var stream = File.OpenRead("data.dat"))
                {
 
                    contacts = formatter.Deserialize(stream) as List<Contact>;
                }
            }
            ContactBindingSource.ResetBindings(false);
            ContactBindingSource.DataSource = contacts;
        }
        public void Save()
        {
            using (var stream = File.OpenWrite("data.dat"))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, ContactBindingSource.DataSource);
            }
        }

        public void New()
        {
            var contact = ContactBindingSource.AddNew() as Contact;
            contact.DateOfBirth = DateTime.Now;
            contact.ContactName = "new conatct";
        }
        public void Delete() => ContactBindingSource.RemoveCurrent();
        public void First() => ContactBindingSource.MoveFirst();
        public void Last() => ContactBindingSource.MoveLast();
        public void Previous() => ContactBindingSource.MovePrevious();
        public void Next() => ContactBindingSource.MoveNext();

        public BindingSource EmailBindingSource { get; set; }
        public BindingSource PhoneBindingSource { get; set; }
        public void NewEmail()
        {
            var email = EmailBindingSource.AddNew() as Email;
            email.EmailAddress = "@gmail.com";
        }
        public void DeleteEmail() => EmailBindingSource.RemoveCurrent();
        public void NewPhone()
        {
            var phone = PhoneBindingSource.AddNew() as Phone;
            phone.Number = "(+84) ";
        }
        public void DeletePhone() => PhoneBindingSource.RemoveCurrent();

        public string Title
        {
            get
            {
                if (ContactBindingSource.Current == null) return "Contacts";
                return $"Contact - {(ContactBindingSource?.Current as Contact)?.ContactName}";
            }
        }
        public void Initialize()
        {
            ContactBindingSource.CurrentChanged += delegate { Notify("Title"); };
        }
        private void Notify([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}