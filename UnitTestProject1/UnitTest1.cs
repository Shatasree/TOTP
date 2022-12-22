using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using WebApplication16;
using WebApplication16.Controllers;
using WebApplication16.Model;
using Xunit;

namespace UnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void GenarateOTP_IsGenarate()
        {
            var ExpectedStatus = "True";
            var getdet = new UserDetails();
            var GenOTP = new APIController();
            var ans = GenOTP.GenarateOTP(getdet);
            OkObjectResult b = ans as OkObjectResult;
            response a = b.Value as response;
            Assert.True(a.Status.Equals(ExpectedStatus));


        }
       // [Theory]
        //public void ValidateOTPIsValidate(string ans)
        //{
        //    var ExpectedStatus = " Valid";
        //    var obj = new OTP();
        //    var valOTP=new APIController();
        //    var ab = valOTP.ValidateOTP(ans);






        //}


    }
}