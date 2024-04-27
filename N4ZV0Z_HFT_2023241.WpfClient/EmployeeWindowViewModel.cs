using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using N4ZV0Z_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace N4ZV0Z_HFT_2023241.WpfClient
{
    internal class EmployeeWindowViewModel : ObservableRecipient
    {
        public RestCollection<Employee> Employees { get; set; }

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                if (value != null)
                {
                    selectedEmployee = new Employee()
                    {
                        EmployeeLastName = value.EmployeeLastName,
                        EmployeeFirstName = value.EmployeeFirstName,
                        EmployeeId = value.EmployeeId,
                        EmployeeAge = value.EmployeeAge,
                        PublisherId = value.PublisherId,
                        EmployeePosition = value.EmployeePosition
                    };
                }
                OnPropertyChanged();
                (DeleteEmployeeCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }



        public ICommand CreateEmployeeCommand { get; set; }
        public ICommand DeleteEmployeeCommand { get; set; }
        public ICommand UpdateEmployeeCommand { get; set; }

        public EmployeeWindowViewModel()
        {
            Employees = new RestCollection<Employee>("http://localhost:35916/", "employee", "hub");
            CreateEmployeeCommand = new RelayCommand(() =>
            {
                Employees.Add(new Employee()
                {
                    EmployeeFirstName = SelectedEmployee.EmployeeFirstName,
                    EmployeeLastName = SelectedEmployee.EmployeeLastName,
                    EmployeeAge = SelectedEmployee.EmployeeAge,
                    EmployeePosition = SelectedEmployee.EmployeePosition,
                    PublisherId = SelectedEmployee.PublisherId
                });
            });

            UpdateEmployeeCommand = new RelayCommand(() =>
            {
                Employees.Update(selectedEmployee);
            });

            DeleteEmployeeCommand = new RelayCommand(() =>
            {
                Employees.Delete(selectedEmployee.EmployeeId);
            },
            () =>
            {
                return selectedEmployee != null;
            });
            selectedEmployee = new Employee();
        }
    }
}