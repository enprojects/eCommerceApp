using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.Requests
{
    public class CustomerBasketRequest
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemRequest> Items { get; set; }
        public int? DeliveryMethodId { get; set; }
        public string ClientSecret { get; set; }
        public string PaymentIntentId { get; set; }
        public decimal ShippingPrice { get; set; }
    }
}