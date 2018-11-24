

using System.Threading.Tasks;
using System.Web.Http;
using BookStore.Domain.Core;
using BookStore.Domain.Interfaces;
using BookStore.Infrastructure.Data;
using Microsoft.AspNet.Identity;

namespace BookStore.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController :  ApiController
    {
        private AuthRepository _repo;
        private IRepository<User> _userrepo;

        public AccountController(IRepository<User> r)
        {
            _repo = new AuthRepository();
            _userrepo = r;
        }
        [System.Web.Mvc.Authorize]
        [System.Web.Mvc.Route("username")]
        [HttpGet]
        public IHttpActionResult GetUserName()
        {
            return Ok(User.Identity.Name);
        }

        // POST api/Account/Register
        [System.Web.Mvc.AllowAnonymous]
        [System.Web.Mvc.Route("Register")]
        public async Task<IHttpActionResult> Register(UserProfile userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }
           
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}