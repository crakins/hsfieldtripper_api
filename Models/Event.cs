using System;
namespace HFT.Models
{
    public class EventItem
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public string EventUrl { get; set; }
        public string ImageUrl { get; set; }
        public decimal PriceChild { get; set; }
        public decimal PriceAdult { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
        public string LocationAddress { get; set; }
        public string AgeRange { get; set; }

    }

    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
