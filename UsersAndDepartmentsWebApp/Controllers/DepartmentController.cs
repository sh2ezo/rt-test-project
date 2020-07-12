using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersAndDepartmentsWebApp.Model;

namespace UsersAndDepartmentsWebApp.Controllers
{
    [Route("[controller]/{Id}")]
    public class DepartmentController : Controller
    {
        private readonly StorageDbContext _db;

        /// <summary>
        /// Creates an instance of the <see cref="DepartmentController"/>.
        /// </summary>
        /// <param name="db"></param>
        public DepartmentController(StorageDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Gets or sets unique identifier of the department.
        /// </summary>
        [FromRoute]
        public int Id { get; set; }

        /// <summary>
        /// Edits department.
        /// </summary>
        /// <param name="title">New title of the department.</param>
        /// <returns>Department.</returns>
        [HttpPut]
        public ActionResult<Department> Edit(string title)
        {
            var department = _db.Departments.Find(Id);

            if (department == null)
            {
                return NotFound();
            }

            department.Title = title;

            _db.SaveChanges();

            return department;
        }

        /// <summary>
        /// Adds users to the department.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>Nothing.</returns>
        [HttpPut]
        [Route("Users")]
        public ActionResult AddUsers(List<int> ids)
        {
            var department = _db.Departments.Find(Id);

            if (department == null)
            {
                return NotFound();
            }

            var users = _db.Users
                .Where(u => ids.Contains(u.Id))
                .ToList();

            using var tx = _db.Database.BeginTransaction();

            foreach (var user in users)
            {
                department.AddUser(user);
            }

            _db.SaveChanges();
            tx.Commit();

            return Ok();
        }

        /// <summary>
        /// Deletes department.
        /// </summary>
        /// <returns>Nothing.</returns>
        [HttpDelete]
        public ActionResult Delete()
        {
            var department = _db.Departments.Find(Id);

            if (department == null)
            {
                return NotFound();
            }

            _db.Remove(department);

            _db.SaveChanges();

            return Ok();
        }
    }
}
