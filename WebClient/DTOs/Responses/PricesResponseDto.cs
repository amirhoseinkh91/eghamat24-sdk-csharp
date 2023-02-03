using System;
using System.Globalization;
using Newtonsoft.Json;

namespace WebClient.DTOs.Responses
{
    public class PricesResponseDto
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public RoomResponseDto[] Result { get; set; }

        [JsonProperty("outputType")]
        public string OutputType { get; set; }

        [JsonProperty("executionTime")]
        public string ExecutionTime { get; set; }
    }
    
    public class RoomResponseDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("nameFa")]
        public string NameFa { get; set; }

        [JsonProperty("fullBoard")]
        public bool FullBoard { get; set; }

        [JsonProperty("beds")]
        public int Beds { get; set; }

        [JsonProperty("onlineReservation")]
        public bool OnlineReservation { get; set; }

        [JsonProperty("reservationStatus")]
        public bool ReservationStatus { get; set; }

        [JsonProperty("discount", NullValueHandling = NullValueHandling.Ignore)]
        public DiscountDto Discount { get; set; }

        [JsonProperty("priceList")]
        [JsonConverter(typeof(PriceListUnionConverter))]
        public PriceListElementDto[] PriceList { get; set; }

        [JsonProperty("eghamat24Discount", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Eghamat24Discount { get; set; }
    }
    
    public class DiscountDto
    {
        [JsonProperty("sales")]
        public string Sales { get; set; }

        [JsonProperty("webservice")]
        public string Webservice { get; set; }
    }
    
    public class PriceListElementDto
    {
        [JsonProperty("persianDate")]
        public string PersianDate { get; set; }

        public DateTime GregorianDate
        {
            get
            {
                var dateParts = PersianDate.Split('-');
                var year = int.Parse($"14{dateParts[0]}");
                var month = int.Parse(dateParts[1]);
                var day = int.Parse(dateParts[2]);
                return new DateTime(year, month, day, new PersianCalendar());
            }
        }
        
        [JsonProperty("date")]
        public DateDto Date { get; set; }

        [JsonProperty("boardPrice")]
        public int BoardPrice { get; set; }

        [JsonProperty("salesPrice")]
        public int SalesPrice { get; set; }

        [JsonProperty("webservicePrice")]
        public long WebservicePrice { get; set; }

        [JsonProperty("extraPersonPrice")]
        public long ExtraPersonPrice { get; set; }

        [JsonProperty("reserveStatus")]
        public bool ReserveStatus { get; set; }
    }
    
    public class DateDto
    {
        [JsonProperty("timeStamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("englishDate")]
        public string EnglishDate { get; set; }

        [JsonProperty("persianDate")]
        public string PersianDate { get; set; }
    }
    
    internal class PriceListUnionConverter : JsonConverter
    {
        public override bool CanConvert(System.Type t) => t == typeof(PriceListElementDto[]);// || t == typeof(PriceListElement?);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, System.Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Boolean:
                    var boolValue = serializer.Deserialize<bool>(reader);
                    return null;
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<PriceListElementDto[]>(reader);
                    return arrayValue;
            }
            throw new Exception("Cannot unmarshal type PriceListUnion");
        }

        public static readonly PriceListUnionConverter Singleton = new PriceListUnionConverter();
    }
}