using Microsoft.AspNetCore.Mvc;

namespace DelfostiChallenge.API.Controllers.v1.Base
{
    public class CustomControllerBase : ControllerBase
    {
        public int IdUser
        {
            get
            {
                var claimId = HttpContext.User.FindFirst("id");
                string claimIdValue = claimId != null ? claimId.Value : "0";
                return Convert.ToInt32(claimIdValue);
            }
        }
    }
}
