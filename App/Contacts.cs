using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
    public partial class Contacts : Form
    {
        private ViewModels.ContactsViewModel _vm = new ViewModels.ContactsViewModel();
        public Contacts()
        {
            InitializeComponent();
            _vm.ContactBindingSource = contactBindingSource;
            _vm.EmailBindingSource = emailBindingSource;
            _vm.PhoneBindingSource = phoneBindingSource;
            _vm.Initialize();
            //##################
            Load += delegate { _vm.Load(); };
            buttonNew.Click += delegate { _vm.New(); };
            buttonDelete.Click += delegate { _vm.Delete(); };
            buttonSave.Click += delegate { _vm.Save(); };
            buttonFirst.Click += delegate { _vm.First(); };
            buttonLast.Click += delegate { _vm.Last(); };
            buttonPrevious.Click += delegate { _vm.Previous(); };
            buttonNext.Click += delegate { _vm.Next(); };
            buttonNewEmail.Click += delegate { _vm.NewEmail(); };
            buttonDeleteEmail.Click += delegate { _vm.DeleteEmail(); };
            buttonNewPhone.Click += delegate { _vm.NewPhone(); };
            buttonDeletePhone.Click += delegate { _vm.DeletePhone(); };

            DataBindings.Add("Text", _vm, "Title");
        }
    }
}
