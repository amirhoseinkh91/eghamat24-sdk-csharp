using System;
using Newtonsoft.Json;

namespace WebClient.DTOs.Responses
{
    public class HotelListResponseDto
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public HotelItemDto[] Result { get; set; }
    }
    
    public class HotelItemDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameFa")]
        public string NameFa { get; set; }

        [JsonProperty("cityNameFa")]
        public string CityNameFa { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("star")]
        public int? Star { get; set; }

        [JsonProperty("class")]
        public long Class { get; set; }

        [JsonProperty("typeNumber", NullValueHandling = NullValueHandling.Ignore)]
        public long? TypeNumber { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("sort")]
        public long Sort { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("onlineReservation")]
        public bool OnlineReservation { get; set; }


        [JsonProperty("parvazyabDiscount")]
        public long? ParvazyabDiscount { get; set; }

        [JsonProperty("transferBy")]
        public long TransferBy { get; set; }

        [JsonProperty("goldenSeconds")]
        public long? GoldenSeconds { get; set; }
        //[JsonProperty("postpaid")]
        //public bool Postpaid { get; set; }

        [JsonProperty("cityName")]
        public string CityName { get; set; }

        [JsonProperty("images")]
        public Uri Images { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("grsKey")]
        public long? GrsKey { get; set; }

        [JsonProperty("doubleRoomCampaign")]
        public bool? DoubleRoomCampaign { get; set; }

        [JsonProperty("sistanCampaign")]
        public bool? SistanCampaign { get; set; }

        [JsonProperty("forBarter")]
        public bool? ForBarter { get; set; }

        [JsonProperty("forYalda")]
        public bool? ForYalda { get; set; }
    }
}