using Entity;
using Semana07.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Semana07.ViewModel
{
    public class ListaCategoriaViewModel : ViewModelBase
    {
        public ObservableCollection<Categoria> Categorias { get; set; }
        public ICommand SelectedItemChanged { get; set; }
        public ICommand NuevoCommand { get; set; }
        public ICommand ConsultarCommand { get; set; }
        public ListaCategoriaViewModel()
        {
            Categorias = new Model.CategoriaModel().Categorias;

            SelectedItemChanged = new RelayCommand<Window>(
                o => {
                    int idCategoria=0;
                    idCategoria = Convert.ToInt32(SelectedItemChanged);
                    View.ManCategoria window = new View.ManCategoria(idCategoria);
                    window.ShowDialog();
                });

            NuevoCommand = new RelayCommand<Window>(
                param => Abrir()
                );

            ConsultarCommand = new RelayCommand<object>(
                o => { Categorias = new Model.CategoriaModel().Categorias; }
                );

            void Abrir()
            {
                View.ManCategoria window = new View.ManCategoria(0);
                window.ShowDialog();
            }
        }
    }
}
