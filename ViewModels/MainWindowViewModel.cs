using System;
using Avalonia.Collections;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using PreExamen.Models;
using PreExamen.Views.Dialogs;

namespace PreExamen.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] CarritoDialog _carritoDialog;
    [ObservableProperty] AvaloniaList<Fruta> _frutas=new();
    [ObservableProperty] Fruta _selectedFruta;
    [ObservableProperty] AvaloniaList<Fruta> _carritoFrutas=new();

    [RelayCommand]
    public void AbrirCarritoDialog()
    {
        CarritoDialog = new CarritoDialog(){DataContext = this};
        DialogHost.Show(CarritoDialog, "AppDialog");

    }

    [RelayCommand]
    public void CargarListaFrutas()
    {
        var uri = new Uri("avares://PreExamen/Assets/fresas.jpg");
        Frutas.Add(new(){ImagePath = new Bitmap(AssetLoader.Open(uri)),Name = "Fresas"});
        uri = new Uri("avares://PreExamen/Assets/manzanas.jpg");
        Frutas.Add(new(){ImagePath = new Bitmap(AssetLoader.Open(uri)),Name = "Manzanas"});
        uri = new Uri("avares://PreExamen/Assets/melones.jpg");
        Frutas.Add(new(){ImagePath = new Bitmap(AssetLoader.Open(uri)),Name = "Melones"});
        uri = new Uri("avares://PreExamen/Assets/naranjas.jpeg");
        Frutas.Add(new(){ImagePath = new Bitmap(AssetLoader.Open(uri)),Name = "Naranjas"});
        uri = new Uri("avares://PreExamen/Assets/peras.jpg");
        Frutas.Add(new(){ImagePath = new Bitmap(AssetLoader.Open(uri)),Name = "Peras"});
    }

    [RelayCommand]
    public void AnadirAlCarrito()
    {
        CarritoFrutas.Add(SelectedFruta);
        SelectedFruta = new();
    }
    
}