using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace photogallery.Models
{
    public partial class PictureInfo : ObservableObject 
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }
        [JsonPropertyName("title")]
        public string Title { get;set; } = string.Empty;
        [JsonPropertyName ("description")]
        public string Description { get;set; } = string.Empty;
        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        public string Path => $"img_{Index}.png";
        [ObservableProperty]
        private int likes = 0;
        


        
    }
}

