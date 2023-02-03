using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using WebClient.Utils;

namespace WebClient.DTOs.Responses
{
    public class CommentResponseDto
    {
        [JsonProperty("rating")] public RatingResponseDto OveralRating { get; set; }
        [JsonProperty("comment")] public List<CommentItemResponseDto> Comments { get; set; }
    }
    
    public class RatingResponseDto
    {
        [JsonProperty("price")] public string Price { get; set; }
        [JsonProperty("facility")] public string Facility { get; set; }
        [JsonProperty("room")] public string Room { get; set; }
        [JsonProperty("position")] public string Position { get; set; }
        [JsonProperty("protocol")] public int Protocol { get; set; }
        [JsonProperty("rate")] public string Rate { get; set; }
        [JsonProperty("totalCounts")] public int TotalCounts { get; set; }
        [JsonProperty("protocolTotalCounts")] public int ProtocolTotalCounts { get; set; }
    }
    
    public class CommentItemResponseDto
    {
        [JsonProperty("passengerName")] public string PassengerName { get; set; }
        [JsonProperty("travelType")] public string TravelType { get; set; }
        [JsonProperty("rate")] public string Rate { get; set; }
        [JsonProperty("negative")] public string NegativeReview { get; set; }
        [JsonProperty("positive")] public string PositiveReview { get; set; }
        [JsonProperty("year")] public string Year { get; set; }
        [JsonProperty("month")] public string Month { get; set; }
        [JsonProperty("day")] public string Day { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        public DateTime? GregorianDate
        {
            get
            {
                var date = $"{Year} {Month} {Day}";
                var keys = date.Split(' ');
                if (keys == null || keys.Length < 3) return null;
                var persianMonthName = keys[1];
                var monthNumber = DateUtils.MonthsMapping[persianMonthName];
                date = date.Replace(persianMonthName, monthNumber).Replace(" ", "/");
                var dateParts = date.Split('/');
                date = dateParts[0] + "/" + dateParts[1] + "/" + dateParts[2];
                return DateUtils.ConvertPersianDateToGregorian(date);
            }
        }
    }
}