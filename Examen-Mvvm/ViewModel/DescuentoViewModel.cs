using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Examen_Mvvm.ViewModel
{
    public partial class DescuentoViewModel : INotifyPropertyChanged
    {
        private decimal _producto1;
        private decimal _producto2;
        private decimal _producto3;

        private decimal _subTotal;
        private decimal _descuento;
        private decimal _total;

        public decimal Producto1
        {
            get => _producto1;

            set
            {
                if (_producto1 != value)
                {
                    _producto1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Producto2
        {
            get => _producto2;

            set
            {
                if(_producto2 != value)
                {
                    _producto2 = value;
                    OnPropertyChanged();
                }
            }
        }
        
        public decimal Producto3
        {
            get => _producto3;

            set
            {
                if (_producto3 != value)
                {
                    _producto3 = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal SubTotal
        {
            get => _subTotal;

            set
            {
                if (_subTotal != value)
                {
                    _subTotal = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Descuento
        {
            get => _descuento;

            set
            {
                if (_descuento != value)
                {
                    _descuento = value;
                    OnPropertyChanged();
                }
            }
        }

        public decimal Total
        {
            get => _total;

            set
            {
                if (_total != value)
                {
                    _total = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand CalcularDescuentoCommand { get; }
        public ICommand LimpiarCommand { get; } 

        public DescuentoViewModel()
        {
            CalcularDescuentoCommand = new RelayCommand(CalcularDescuento);
            LimpiarCommand = new RelayCommand(Limpiar);
        }

        private void CalcularDescuento()
        {
            try
            {
                if (Producto1 < 0 || Producto2 < 0 || Producto3 < 0)
                {
                    throw new ArgumentException("Los Valores de los Productos no pueden ser negativos");
                }

                SubTotal = Producto1 + Producto2 + Producto3;

                Descuento = SubTotal switch
                {
                    >= 10000 => SubTotal * 0.30m,
                    >= 5000 and < 10000 => SubTotal * 0.20m,
                    >= 1000 and < 5000 => SubTotal * 0.10m,
                    _ => 0
                };

                Total = SubTotal - Descuento;
            }
            catch (Exception ex)
            {
                Total = 0;
                Descuento = 0;

                System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        private void Limpiar()
        {
            Producto1 = 0;
            Producto2 = 0;
            Producto3 = 0;
            SubTotal = 0;
            Descuento = 0;
            Total = 0;
        }
    }
}
