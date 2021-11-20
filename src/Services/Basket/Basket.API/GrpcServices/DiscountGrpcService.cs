using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discount.gRPC.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _discountProtoService;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient discountProtoService)
        {
            _discountProtoService =
                discountProtoService ?? throw new ArgumentNullException(nameof(discountProtoService));
        }

        public async Task<CouponModel> GetDiscount(string productName)
        {
            var discountRequest = new GetDiscountRequset() {ProductName = productName};
            return await _discountProtoService.GetDiscountAsync(discountRequest);
        }
    }
}
