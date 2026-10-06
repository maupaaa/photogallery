//using Android.App;
using CommunityToolkit.Mvvm.ComponentModel;
using photogallery.Services;
using System;
using System.Collections.Generic;
using System.Text;
using photogallery.Models;
using CommunityToolkit.Mvvm.Input;
namespace photogallery.Viewmodels;

public partial class GalleryViewModel : ObservableObject
{
    private PictureInfoService _service;
    private int _currentIndex = 0;
    [ObservableProperty]
    private PictureInfo? _currentPicture;

    private void LoadPicture(int index)
    {
        if (_service.Count > 0)
        {
            CurrentPicture = _service.GetPictureInfo(index);
        }
    }
    public GalleryViewModel()
    {
        _service = new PictureInfoService();
        LoadPicture(_currentIndex);
    }
    [RelayCommand]
    private void Like()
    {
        CurrentPicture.Likes++;
    }

    [RelayCommand]
    private void Unlike()
    {
        if (CurrentPicture.Likes > 0)
        {
            CurrentPicture.Likes--;
        }
       
    }

    [RelayCommand]
    private void Next()
    {
        if (_currentIndex == (_service.Count) - 1)
        {
            _currentIndex = 0;
            LoadPicture(_currentIndex);
        }
        else
        {
            _currentIndex++;
            LoadPicture(_currentIndex);
        }
        
    }
    [RelayCommand]
    private void Previous()
    {
        if (_currentIndex == 0)
        {
            _currentIndex = _service.Count - 1;
            LoadPicture(_currentIndex);
        }
        else
        {
            _currentIndex--;
            LoadPicture(_currentIndex);
        }
    }
    [RelayCommand]
    private async Task ShowLocationAsync()
    {
        await Shell.Current.DisplayAlertAsync("Lokalizacja", CurrentPicture.City, "OK");
    }
}
