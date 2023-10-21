using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Services
{
    public interface IPaymentService
    {
        void ProcessPayment(PaymentInfoDTO paymentInfoDTO);
    }
}