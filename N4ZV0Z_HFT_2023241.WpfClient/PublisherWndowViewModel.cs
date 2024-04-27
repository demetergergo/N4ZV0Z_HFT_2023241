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
    internal class PublisherWndowViewModel : ObservableRecipient
    {
        public RestCollection<Publisher> Publishers { get; set; }

        private Publisher selectedPublisher;

        public Publisher SelectedPublisher
        {
            get { return selectedPublisher; }
            set
            {
                if (value != null)
                {
                    selectedPublisher = new Publisher()
                    {
                        PublisherName = value.PublisherName,
                        PublisherId = value.PublisherId
                    };
                }
                OnPropertyChanged();
                (DeletePublisherCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }



        public ICommand CreatePublisherCommand { get; set; }
        public ICommand DeletePublisherCommand { get; set; }
        public ICommand UpdatePublisherCommand { get; set; }

        public PublisherWndowViewModel()
        {
            Publishers = new RestCollection<Publisher>("http://localhost:35916/", "publisher", "hub");
            CreatePublisherCommand = new RelayCommand(() =>
            {
                Publishers.Add(new Publisher()
                {
                    PublisherName = SelectedPublisher.PublisherName
                });
            });

            UpdatePublisherCommand = new RelayCommand(() =>
            {
                Publishers.Update(SelectedPublisher);
            });

            DeletePublisherCommand = new RelayCommand(() =>
            {
                Publishers.Delete(SelectedPublisher.PublisherId);
            },
            () =>
            {
                return SelectedPublisher != null;
            });
            SelectedPublisher = new Publisher();
        }
    }
}
