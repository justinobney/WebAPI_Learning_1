using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MediatR;
using WebAPI_Learning_1.Data.Users;
using WebAPI_Learning_1.Requests.Commands;
using WebAPI_Learning_1.Requests.Queries;

namespace WebAPI_Learning_1.Controllers
{
    public class UsersController : ApiController
    {
        private readonly Mediator _mediator;

        public UsersController(Mediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Users
        public IHttpActionResult GetUsers()
        {
            var users = _mediator.Send(new GetUsersQuery());
            return Ok(users);
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(long id)
        {
            var user = await _mediator.SendAsync(new GetUserQuery { Id = id });
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(CreateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _mediator.SendAsync(command);
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }


        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(long id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await _mediator.SendAsync(command);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(long id)
        {
            var user = await _mediator.SendAsync(new DeleteUserCommand {Id = id});
            return Ok(user);
        }
        
    }
    
}