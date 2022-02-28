﻿using Discount.Grpc.Controllers;
using System.Threading.Tasks;

namespace Discount.Grpc.Repository
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productName);
        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool> DeleteDiscount(string productName);    
    }
}