using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPI_Learning_1.Data;
using WebAPI_Learning_1.Data.Users;

namespace WebAPI_Learning_1.Controllers
{
    public class UsersController : ApiController
    {
        private readonly UserRepository _userRepo;

        public UsersController(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return _userRepo.GetAll();
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUser(long id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.ModifiedAt = DateTime.UtcNow;
            await _userRepo.InsertAsync(user);
            
            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }


        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUser(long id, User user)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != user.Id)
            {
                return BadRequest();
            }

            user.ModifiedAt = DateTime.UtcNow;

            try
            {
                await _userRepo.UpdateAsync(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                var userExists = await UserExists(id);
                if (!userExists)
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> DeleteUser(long id)
        {
            User user = await _userRepo.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userRepo.DeleteAsync(user);
            return Ok(user);
        }
        
        private async Task<bool> UserExists(long id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            return user != null;
        }
    }
}