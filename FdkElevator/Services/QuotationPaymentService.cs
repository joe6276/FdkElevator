using FdkElevator.AppDbContext;
using FdkElevator.DTOS.TenantDTOS;
using FdkElevator.Models.Projects;
using FdkElevator.Models.Quotations;
using FdkElevator.Models.Tenants;
using FdkElevator.Services.IServices;
using Microsoft.EntityFrameworkCore;
using Stripe;
using Stripe.Checkout;

namespace FdkElevator.Services
{
    public class QuotationPaymentService : IQuotationPayment
    {
        private readonly ApplicationDbContext _context;
        public QuotationPaymentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<QuotationPayment> GetQuotations(Guid clientId)
        {
            var payments = _context.quotationPayments.Where(x=>x.ClientId == clientId).ToList();
            return payments;

        }
        public string GenerateProjectCode()
        {
            return $"PRJ-{Guid.NewGuid().ToString("N")[..8].ToUpper()}";
        }
        public PaymentResponseDTO MakePayment(Guid Id)
        {
            var payment = _context.quotationPayments.FirstOrDefault(x => x.Id == Id);

            if (payment == null)
            {
                throw new Exception("Payment not Found");
            }

            var options = new SessionCreateOptions()
            {
                SuccessUrl = "https://thankful-island-0f523aa0f.7.azurestaticapps.net/client/quotations?payment=success",
                CancelUrl = " https://thankful-island-0f523aa0f.7.azurestaticapps.net/client/quotations?payment=failure",
                Mode = "payment",
                LineItems = new List<SessionLineItemOptions>()
            };

            var sessionLineItem = new SessionLineItemOptions()
            {
                PriceData = new SessionLineItemPriceDataOptions()
                {
                    Currency = "usd",
                    UnitAmountDecimal = payment.Amount * 100,
                    ProductData = new SessionLineItemPriceDataProductDataOptions()
                    {
                        Name = $"Payment for Quotation {payment.QuotationId}"
                    }
                },
                Quantity = 1

            };

            options.LineItems.Add(sessionLineItem);


            var service = new SessionService();
            var session = service.Create(options);

            payment.StripeSessionId = session.Id;

            _context.quotationPayments.Update(payment);
            _context.SaveChanges();

            var response = new PaymentResponseDTO()
            {
                StripeSessionId = session.Id,
                URL=session.Url
            };

            return response;
        }

        public string validatePayment(string stripeSessionId)
        {
            var payment = _context.quotationPayments
      .Include(p => p.revision)
          .ThenInclude(r => r.Lead)
      .Include(p => p.quotation)
          .ThenInclude(q => q.Lead)
      .FirstOrDefault(p => p.StripeSessionId == stripeSessionId);
            if (payment == null)
            {
                throw new Exception("Payment not Found");
            }

            var service = new SessionService();
            var session = service.Get(stripeSessionId);

            var paymentIntentService = new PaymentIntentService();

            var id = session.PaymentIntentId;

            if (id == null)
            {
                throw new Exception("Payment Intent Id is null");
            }

            PaymentIntent paymentIntent = paymentIntentService.Get(id);

            if (paymentIntent.Status == "succeeded")
            {
                payment.Status = PaymentStatus.Completed;
                payment.PaymentIntentId = paymentIntent.Id;
                _context.quotationPayments.Update(payment);
                _context.SaveChanges();

               var TenantId = payment.QuotationId==null? payment.revision.Lead.TenantId : payment.quotation.Lead.TenantId;
                var project = new Project()
                {
                    ClientId = payment.ClientId,
                    TenantId = TenantId,
                    ProjectCode = GenerateProjectCode(),
                };
                _context.projects.Add(project);
                _context.SaveChanges();


                var items = _context.QuoteItems.Where(x => x.QuotationId == payment.QuotationId).ToList();

                var materials = new List<Material> ();
                foreach (var item in items)
                {
                    var material = new Material()
                    {
                        MaterialName = item.ItemName,
                        ProjectId = project.Id,
                    };

                    materials.Add(material);

                }
                _context.materials.AddRange(materials);
                _context.SaveChanges();


                return "Payment Successful";
            }
            else if (paymentIntent.Status == "requires_payment_method" || paymentIntent.Status == "requires_action")
            {
                payment.Status = PaymentStatus.Failed;
                payment.PaymentIntentId = paymentIntent.Id;
                _context.quotationPayments.Update(payment);
                _context.SaveChanges();
                return "Payment Failed";
            }
            else
            {
                return "Payment is still pending";

            }
        }
    }
}
