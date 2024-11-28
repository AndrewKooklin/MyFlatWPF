using MyFlatWPF.Data.Repositories.API;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyFlatWPF.Commands.ManagementCommand
{
    public class ShowAllOrdersCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        APIManagementRepository _api = new APIManagementRepository();

        public ShowAllOrdersCommand()
        {
            StatusNames = new ObservableCollection<string>(_api.GetStatusNames());
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<string> _statusNames;
        public ObservableCollection<string> StatusNames
        {
            get
            {
                return _statusNames;
            }
            set
            {
                _statusNames = value;
                OnPropertyChanged(nameof(StatusNames));
            }
        }
    }
}
