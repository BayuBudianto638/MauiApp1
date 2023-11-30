using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Applications.Customers;
using MauiApp1.Models;
using MauiApp1.Views.Customer;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiApp1.ViewModels
{
    public partial class CustomerViewModel : ObservableObject
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly INavigation _navigation;

        //public ICommand SetOperatingCustomerCommand { get; set; }

        public CustomerViewModel(ICustomerAppService customerAppService, INavigation navigation)
        {
            _customerAppService = customerAppService;
            _navigation = navigation;
        }

        public ICommand SetOperatingCustomerCommand => new Command<CustomerModel>(async (customer) =>
        {
            await _navigation.PushAsync(new CustomerPageAdd());
        });

        [ObservableProperty]
        private ObservableCollection<CustomerModel> _customers = new();

        [ObservableProperty]
        private CustomerModel _operatingCustomer = new();

        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _busyText;

        public CustomerModel OperatingCostumer { get; private set; }

        public async Task LoadCustomersAsync()
        {
            await ExecuteAsync(async () =>
            {
                var costumers = await _customerAppService.GetAll();
                if (costumers is not null && costumers.Any())
                {
                    Customers ??= new ObservableCollection<CustomerModel>();

                    foreach (var costumer in costumers)
                    {
                        Customers.Add(costumer);
                    }
                }
            }, "Fetching costumers...");
        }

        [RelayCommand]
        private void SetOperatingCostumer(CustomerModel? costumer) => OperatingCostumer = costumer ?? new();

        [RelayCommand]
        private async Task SaveCustomerAsync()
        {
            if (OperatingCostumer is null)
                return;

            var busyText = OperatingCostumer.Id == 0 ? "Creating customer..." : "Updating customer...";
            await ExecuteAsync(async () =>
            {
                if (OperatingCostumer.Id == 0)
                {
                    // Create customer
                    var (isCreate, isMsg) = await _customerAppService.Save(OperatingCostumer);
                }
                else
                {
                    // Update customer
                    var isUpdate = await _customerAppService.Update(OperatingCostumer);
                    if (isUpdate)
                    {
                        await Shell.Current.DisplayAlert("Success", "Customer updation success", "Ok");
                        return;
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Error", "Product updation error", "Ok");
                        return;
                    }
                }
                SetOperatingCustomerCommand.Execute(new());
            }, busyText);
        }

        [RelayCommand]
        private async Task DeleteCustomerAsync(int id)
        {
            bool answer = await Shell.Current.DisplayAlert("Question?", "Do you want to delete this record?", "Yes", "No");

            if (answer.Equals(true))
            {
                await ExecuteAsync(async () =>
                {
                    var isDeleted = await _customerAppService.Delete(id);
                    if (isDeleted)
                    {
                        await Shell.Current.DisplayAlert("Delete Success", "Customer was deleted", "Ok");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("Delete Error", "Customer was not deleted", "Ok");
                    }
                }, "Deleting customer...");
            }
            
        }

        private async Task ExecuteAsync(Func<Task> operation, string? busyText = null)
        {
            IsBusy = true;
            BusyText = busyText ?? "Processing...";
            try
            {
                await operation?.Invoke();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsBusy = false;
                BusyText = "Processing...";
            }
        }
    }
}
