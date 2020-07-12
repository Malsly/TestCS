using BL.Abstract;
using BL.Impl;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Data;
using ViewModels.Infrastructure;

namespace ViewModels
{
    public class ShipmentRegistrationVM : INotifyPropertyChanged
    {
        private Dictionary<string, bool> checkGroups;
        private Dictionary<string, Visibility> visibilityGroups;
        private ICollectionView shipmentRegistrations;
        private readonly IShipmentRegistrationService shipmentRegistrationService = new ShipmentRegistrationService();
        private int totalCount;
        private float totalSum;
        public int TotalCount
        {
            get { return totalCount; }
            set
            {
                totalCount = value;
                OnPropertyChanged(nameof(TotalCount));
            }
        }
        public float TotalSum
        {
            get { return totalSum; }
            set
            {
                totalSum = value;
                OnPropertyChanged(nameof(TotalSum));
            }
        }
        public Dictionary<string, bool> CheckGroups
        {
            get { return checkGroups; }
            set
            {
                checkGroups = value;
                OnPropertyChanged(nameof(CheckGroups));
            }
        }

        public Dictionary<string, Visibility> VisibilityGroups
        {
            get { return visibilityGroups; }
            set
            {
                visibilityGroups = value;
                OnPropertyChanged(nameof(VisibilityGroups));
            }
        }

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

            ShipmentRegistrations = CollectionViewSource.GetDefaultView(shipmentRegistrationFromService);

            RefreshGroups();
            RefreshCount();
            RefreshSum();
            RefreshVisibilityGroups();

            OnPropertyChanged(nameof(shipmentRegistrations));
            
        }

        private RelayCommand useGrouping;
        public RelayCommand UseGrouping
        {
            get
            {
                return useGrouping ??
                  (useGrouping = new RelayCommand(obj =>
                  {
                      BindVisabilityToCheckGroups();
                      OnPropertyChanged(nameof(VisibilityGroups));
                  }));
            }
        }

        private RelayCommand resetGrouping;
        public RelayCommand ResetGrouping
        {
            get
            {
                return resetGrouping ??
                  (resetGrouping = new RelayCommand(obj =>
                  {
                      RefreshVisibilityGroups();
                      RefreshGroups();
                  }));
            }
        }

        public void RefreshSum()
        {
            float newSum = 0;
            foreach (ShipmentRegistrationDTO dto in ShipmentRegistrations) 
            {
                newSum += dto.Summa;
            }
            TotalSum = newSum;
        }
        public void RefreshCount()
        {
            int newCount = 0;
            foreach (ShipmentRegistrationDTO dto in ShipmentRegistrations)
            {
                newCount += dto.Count;
            }
            TotalCount = newCount;
        }

        public void RefreshGroups() 
        {
            CheckGroups = new Dictionary<string, bool>()
            {
                {"Date", false},
                {"Organisation", false},
                {"City", false},
                {"Country", false},
                {"Manager", false},
                {"Count", false},
                {"Summa", false}
            };
        }

        public void BindVisabilityToCheckGroups() 
        {
            VisibilityGroups = new Dictionary<string, Visibility>();
            foreach (KeyValuePair<string, bool> entry in CheckGroups) 
            {
                if(entry.Value) 
                {
                    VisibilityGroups.Add(entry.Key, Visibility.Hidden);
                }
                else 
                {
                    VisibilityGroups.Add(entry.Key, Visibility.Visible);
                }
            }    
        }

        public void RefreshVisibilityGroups()
        {
            VisibilityGroups = new Dictionary<string, Visibility>() 
            {
                {"Date", Visibility.Visible},
                {"Organisation", Visibility.Visible},
                {"City", Visibility.Visible},
                {"Country", Visibility.Visible},
                {"Manager", Visibility.Visible},
                {"Count", Visibility.Visible},
                {"Summa", Visibility.Visible}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
