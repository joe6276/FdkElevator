using FdkElevator.AppDbContext;
using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Models.Organization;
using FdkElevator.Models.Tenant;
using FdkElevator.Services.IServices;
using Microsoft.AspNetCore.SignalR;
using Stripe;
using Stripe.Checkout;
using Stripe.Climate;

namespace FdkElevator.Services
{
    public class TenantSubService : ITenantSub
    {
        private readonly ApplicationDbContext _context; 
        public TenantSubService(ApplicationDbContext context)
        {
            _context = context;
        }


        public PaymentResponseDTO addTenant(TenantSub sub)
        {
           var tenant = _context.Tenants.FirstOrDefault(t => t.Id == sub.TenantId);
        

            if (tenant == null)
            {
                throw new Exception("Tenant not Found!");
            }

            var options = new SessionCreateOptions()
            {
                SuccessUrl = "https://autopartafrica.com/success",
                CancelUrl = "https://autopartafrica.com/orders/payment-cancelled",
                Mode = "payment",
                LineItems = new List<SessionLineItemOptions>()
            };


            var sessionLineItem = new SessionLineItemOptions()
            {
                PriceData = new SessionLineItemPriceDataOptions()
                {
                    Currency = "usd",
                    UnitAmount = (long)sub.Amount * 100,
                    ProductData = new SessionLineItemPriceDataProductDataOptions()
                    {
                        Name =" Subscription Payment"

                    }
                },
                Quantity = 1
            };
                
            options.LineItems.Add(sessionLineItem);


            var service = new SessionService();
            Session session = service.Create(options);

            sub.StripeSessionId = session.Id;

            _context.TenantSubs.Add(sub);
            _context.SaveChanges();


            return new PaymentResponseDTO
            {
                URL = session.Url,
                StripeSessionId = session.Id
            };
        }




        public bool ValidatePayment(string stripeSessionId)
        {
            var tenantSub = _context.TenantSubs.Where(x => x.StripeSessionId == stripeSessionId).FirstOrDefault();
            var organization = _context.Organizations.FirstOrDefault();
            var tenant = _context.Tenants.FirstOrDefault(t => t.Id == tenantSub.TenantId);

            if (tenantSub != null)
            {
                var service = new SessionService();
                Session session = service.Get(stripeSessionId);

                var paymentIntentService = new PaymentIntentService();
                var id = session.PaymentIntentId;

                if (id == null)
                {
                    throw new Exception("Payment Intent not found");
                }

                PaymentIntent paymentIntent = paymentIntentService.Get(id);
                if (paymentIntent.Status == "succeeded")
                {

                    if ((float)tenantSub.Amount == organization.FreePlanCost)
                    {
                        tenant.Subscription_Plan = Subscription_Plan.Free;
                    }
                    else if ((float)tenantSub.Amount == organization.BasicPlanCost)
                    {
                        tenant.Subscription_Plan = Subscription_Plan.Basic;
                    }
                    else if ((float)tenantSub.Amount == organization.PremiumPlanCost)
                    {
                        tenant.Subscription_Plan = Subscription_Plan.Premium;
                    }

                    tenant.Subscription_Status = Subscription_Status.Active;
                    tenant.isActive = true;
                    tenant.SubscriptionExpiresAt = DateTime.UtcNow.AddDays(30);

                    _context.Tenants.Update(tenant);
                    _context.SaveChanges();


                    tenantSub.StripePaymentIntent = id;

                    _context.TenantSubs.Update(tenantSub);
                    _context.SaveChanges();

                    return true;
                }
                else
                {
                    return  false;
                }

                throw new Exception("Request unsuccessfull!");
            }
            throw new Exception("Request unsuccessfull!");
        }
    }
}
