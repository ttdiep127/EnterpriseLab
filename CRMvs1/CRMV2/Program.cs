
namespace CRMV2
{
    class Program
    {
        static void Main(string[] args)
        {
            var ui = new UIManager();
            var storage = new CustomerStorage();
            bool isContinue = true;

            do
            {
                var action = ui.AskForAction();
                switch (action)
                {
                    case UserAction.AddCustomer:
                        var newCustomer = ui.InputNewCustomer();
                        storage.AddCustomer(newCustomer);
                        break;
                    case UserAction.EditCustomer:
                        if (ui.ShowCustomers(storage))
                        {
                            var customerEdit = ui.SelectCustomer(storage);
                            var updatedCustomer = ui.ModifyACustomer(customerEdit);
                            storage.UpdateCustomer(updatedCustomer);
                        }
                        break;
                    case UserAction.DeleteCustomer:
                        if (ui.ShowCustomers(storage))
                        {
                            var customerDelete = ui.SelectCustomer(storage);
                            storage.DeleteCustomer(customerDelete);
                        }
                        break;
                    case UserAction.ViewCustomer:
                        if (ui.ShowCustomers(storage))
                        {
                            if (ui.AskShowCustomerDetail())
                            {
                                var customerShow = ui.SelectCustomer(storage);
                                storage.ShowCustomerDetail(customerShow);
                            }
                        }
                        break;
                    case UserAction.Exit:
                        isContinue = false;
                        break;
                    default:
                        break;
                }
            } while (isContinue);
        }
    }
}
