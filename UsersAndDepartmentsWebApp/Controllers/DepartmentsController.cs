using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UsersAndDepartmentsModel;
using UsersAndDepartmentsWebApp.Model;

namespace UsersAndDepartmentsWebApp.Controllers
{
    [Route("[controller]")]
    public class DepartmentsController : Controller
    {
        private readonly StorageDbContext _db;

        /// <summary>
        /// Creates an instance of the <see cref="DepartmentsController"/>.
        /// </summary>
        /// <param name="db"></param>
        public DepartmentsController(StorageDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Creates new department.
        /// </summary>
        /// <param name="title">Title of the new department.</param>
        /// <returns>Created department.</returns>
        [HttpPost]
        public ActionResult<Department> Create(string title)
        {
            var department = new Department
            {
                Title = title,
            };

            _db.Add(department);
            _db.SaveChanges();

            return department;
        }

        /// <summary>
        /// Lists all departments.
        /// </summary>
        [HttpGet]
        public List<Department> Get()
        {
            return _db.Departments.ToList();
        }
    }
}
