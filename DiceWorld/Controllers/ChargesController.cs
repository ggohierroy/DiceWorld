using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DiceWorld.Models;
using Stripe;

namespace DiceWorld.Controllers
{
    public class ChargesController : ApiController
    {
        // POST api/values
        public void Post([FromBody]Charge charge)
        {
            var myCharge = new StripeChargeCreateOptions();

            // always set these properties
            myCharge.Amount = 5153;
            myCharge.Currency = "usd";

            // set this if you want to
            myCharge.Description = "Charge it like it's hot";

            // set this property if using a token
            myCharge.TokenId = charge.TokenId;

            // set this if you have your own application fees (you must have your application configured first within Stripe)
            myCharge.ApplicationFee = 25;

            // (not required) set this to false if you don't want to capture the charge yet - requires you call capture later
            myCharge.Capture = true;

            var chargeService = new StripeChargeService();

            try
            {
                StripeCharge stripeCharge = chargeService.Create(myCharge);
            }
            catch(StripeException ex)
            {
                
            }
        }
    }
}
