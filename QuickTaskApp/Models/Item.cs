using System;

namespace QuickTaskApp.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
    }
}