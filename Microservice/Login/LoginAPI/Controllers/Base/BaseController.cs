using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace Login.API.Controllers.Base
{

    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult ResponseResult<T>(ErrorOr<T> result)
        {
            return result.Match(
                   result => Ok(result),
                   errors => Problem(
                                        statusCode: StatusCodes.Status500InternalServerError,
                                        title: errors.FirstOrDefault().Description
                                    )
                               );
        }
    }
}
