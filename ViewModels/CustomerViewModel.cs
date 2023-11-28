using MauiApp1.Applications.Customers;
using MauiApp1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    internal class CustomerViewModel : INotifyPropertyChanged
    {
        readonly IList<CustomerModel> source;
        CustomerModel selectedCustomer;

        public ObservableCollection<CustomerModel> Customers { get; set; }

        public CustomerModel SelectedCustomer
        {
            get
            {
                return selectedCustomer;
            }
            set
            {
                if (selectedCustomer != value)
                {
                    selectedCustomer = value;
                }
            }
        }

        public ICommand DeleteCommand => new Command(RemoveCustomer);
        public ICommand FavoriteCommand => new Command(EditCustomer);

        public CustomerViewModel()
        {
            source = new List<CustomerModel>();
            CreateCustomerCollection();


            //SelectedCustomer = Customer.Skip(3).FirstOrDefault();
            OnPropertyChanged("SelectedCustomer");

        }

        async void CreateCustomerCollection()
        {
            var customerAppService = new CustomerAppService();

            var data = await customerAppService.GetAll();

            Customers = new ObservableCollection<CustomerModel>(data);
        }

        void RemoveCustomer()
        {

        }

        void EditCustomer()
        {

        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
