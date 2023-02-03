// See https://aka.ms/new-console-template for more information

using WebClient;
using WebClient.DTOs.Responses;

var config = new Configuration("https://www.eghamat24.com", "f8991M39df5Te10d0Afa852w");
var client = new Client(config);

var hotels = client.GetHotelsByCityAsync("Ahvaz").Result;

Console.WriteLine("END");