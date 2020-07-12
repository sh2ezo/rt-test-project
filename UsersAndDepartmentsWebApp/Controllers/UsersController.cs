using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAndDepartmentsWebApp.Model;

namespace UsersAndDepartmentsWebApp.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private StorageDbContext _db;

        /// <summary>
        /// Creates an instance of the <see cref="UsersController"/>.
        /// </summary>
        /// <param name="db"></param>
        public UsersController(StorageDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <param name="fullname">Full name of the user.</param>
        /// <param name="departmentId">Unique identifier of the department the user will belong to.</param>
        /// <returns>User.</returns>
        [HttpPost]
        public ActionResult<User> Create(string fullname, int departmentId)
        {
            var department = _db.Departments.Find(departmentId);

            if (department == null)
            {
                return BadRequest();
            }

            var user = new User
            {
                FullName = fullname,
                DepartmentId = departmentId,
            };

            _db.Users.Add(user);

            _db.SaveChanges();

            return user;
        }

        /// <summary>
        /// Lists all users filtered by <paramref name="departmentIds"/>.
        /// </summary>
        /// <param name="departmentIds">Unique identifiers of the departments to return users from.</param>
        /// <returns>List of users.</returns>
        [HttpGet]
        public List<User> Get(List<int> departmentIds)
        {
            if (departmentIds == null || departmentIds.Count == 0)
            {
                return new List<User>();
            }

            return _db.Users
                .Where(u => departmentIds.Contains(u.DepartmentId))
                .ToList();
        }

        /// <summary>
        /// Returns all registered users.
        /// </summary>
        /// <returns>List of users.</returns>
        [Route("All")]
        [HttpGet]
        public List<User> Get()
        {
            return _db.Users.ToList();
        }
    }
}
