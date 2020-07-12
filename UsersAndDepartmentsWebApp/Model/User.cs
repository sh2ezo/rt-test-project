namespace UsersAndDepartmentsWebApp.Model
{
    public class User
    {
        /// <summary>
        /// Creates a new instance of the <see cref="User"/>.
        /// </summary>
        public User()
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="User"/>.
        /// </summary>
        /// <param name="id">Unique identifier of the user.</param>
        public User(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets unique identifier of the user.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or sets unique identifier of the department ths user belongs to.
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets the full name of the user.
        /// </summary>
        public string FullName { get; set; }
    }
}
