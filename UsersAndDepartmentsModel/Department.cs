using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace UsersAndDepartmentsModel
{
    public class Department
    {
        private readonly List<User> _users = new List<User>();

        /// <summary>
        /// Creates a new instance of the <see cref="Department"/>.
        /// </summary>
        public Department()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="Department"/>.
        /// </summary>
        /// <param name="id">Unique identifier of the department.</param>
        [JsonConstructor]
        public Department(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets unique identifier of the department.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or sets title of the department.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets users that belong to the department.
        /// </summary>
        [JsonIgnore]
        public IReadOnlyList<User> Users => _users;

        /// <summary>
        /// Adds user to the department.
        /// </summary>
        /// <param name="user"></param>
        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            user.DepartmentId = Id;

            _users.Add(user);
        }
    }
}
