using BL.Abstract;
using BL.Impl;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Data;

namespace ViewModels
{
    public class ShipmentRegistrationVM : INotifyPropertyChanged
    {
        private ICollectionView shipmentRegistrations;
        private readonly IShipmentRegistrationService shipmentRegistrationService = new ShipmentRegistrationService();

        public ICollectionView ShipmentRegistrations
        {
            get { return shipmentRegistrations; }
            set
            {
                shipmentRegistrations = value;
                OnPropertyChanged(nameof(ShipmentRegistrations));
            }
        }

        public ShipmentRegistrationVM()
        {
            IList<ShipmentRegistrationDTO> shipmentRegistrationFromService = new List<ShipmentRegistrationDTO>();
            
            shipmentRegistrationFromService = shipmentRegistrationService.GetAll().Data;

            shipmentRegistrations = CollectionViewSource.GetDefaultView(shipmentRegistrationFromService);
            OnPropertyChanged(nameof(shipmentRegistrations));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
