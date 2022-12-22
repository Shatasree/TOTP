using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TOTP.Model;
using WebApplication16.Model;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication16.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
    //    private UserDetails getdet;

    //    public APIController(UserDetails getdet)
    //    {
    //        this.getdet = getdet;
    //    }

        //private ActionResult result;

        [HttpPost]
        [Route("GenarateOTP")]
        public  IActionResult GenarateOTP(Model.UserDetails details)

        {
            LOG.WriteLog("Started");
         
            OTP OTP = new OTP();
            details.EmailId = "abc@gmail.com";
            var status = OTP.GenarateOTP();
            if (status != null)
            {
                LOG.WriteLog("OTP Genarated");
                return Ok(new response { GenarateOTP = status, StatusCode = "200", Status = "True", Message = "OTP is  genarated" });
            }
            else
            {
                LOG.WriteLog("OTP ");
                return Ok(new response { GenarateOTP = status, StatusCode = "422", Status="false" ,Message="OTP is not genarated" , });
            }
            var a = new response { GenarateOTP = status };
            
            return Ok(a);
        }

       

        [HttpGet]
        [Route("ValidateOTP")]
        public  IActionResult ValidateOTP(string OTP)

        {
            LOG.WriteLog("OTP Validation Started");

            OTP o = new OTP();
            var test = o.ValidOTP(OTP);
            if (test)
            {
                return Ok(new Validresponse { otptest = test, StatusCode = "200", Status = "True", Message = "OTP is Validate" });
                LOG.WriteLog("OTP Validated");
            }

           
   
           else
            {
                return Ok(new Validresponse { otptest = test, StatusCode = "422", Status = "False", Message = "OTP is  not Validated" });
            }
            LOG.WriteLog("Execution Completed");

            //}
        }
        //HttpGet]
       // [Route("AnotherMethod")]
       // public IActionResult AnotherMethod( )
        //{
            //if(otptest)
           // return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status200OK);

       // }

    }
}
