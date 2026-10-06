using photogallery.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace photogallery.Services
{
    public class PictureInfoService
    {
        // Lista zdjęć
        private List<PictureInfo> _pictureInfos;

        public PictureInfoService()
        {
            // Tutaj możemy umieścić wywołanie InitializeAsync(), ale musimy zaczekać na jej zakończenie
            Task.Run(async ()=> await InitializeAsync()).GetAwaiter().GetResult();
        }

        private async Task InitializeAsync()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("pictures.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();

            _pictureInfos = JsonSerializer.Deserialize<List<PictureInfo>>(contents)??new List<PictureInfo>() ;
        }

        public PictureInfo GetPictureInfo(int index)
        {
            // Pobieranie zdjęcia o zadanym indexsie
            return _pictureInfos[index];
        }

       public int Count { get { return _pictureInfos.Count; } }
    }
}
