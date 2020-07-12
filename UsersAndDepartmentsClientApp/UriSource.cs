using System;
using System.Collections.Generic;
using System.Text;

namespace UsersAndDepartmentsClientApp
{
    internal static class UriSource
    {
        /// <summary>
        /// Returns uri to get list of departments.
        /// </summary>
        /// <returns>Uri.</returns>
        public static Uri GetDepartmentsUri()
        {
            return new Uri("Departments", UriKind.Relative);
        }

        /// <summary>
        /// Returns uri to get list of users that belong to the department.
        /// </summary>
        /// <param name="departmentId">Unique identifier of the department.</param>
        /// <returns>Uri.</returns>
        public static Uri GetDepartmentUsersListUri(int departmentId)
        {
            return new Uri($"Users?departmentIds={departmentId}", UriKind.Relative);
        }

        /// <summary>
        /// Returns uri to work with specified department.
        /// </summary>
        /// <param name="departmentId">Unique identifier of the department.</param>
        /// <returns>Uri.</returns>
        public static Uri GetDepartmentUri(int departmentId)
        {
            return new Uri($"Department/{departmentId}", UriKind.Relative);
        }

        /// <summary>
        /// Returns uri to work with users of the specified department.
        /// </summary>
        /// <param name="departmentId">Unique identifier of the department.</param>
        /// <returns>Uri.</returns>
        public static Uri GetDepartmentUsersUri(int departmentId)
        {
            return new Uri($"Department/{departmentId}/Users", UriKind.Relative);
        }

        /// <summary>
        /// Returns uri to work with users.
        /// </summary>
        /// <returns>Uri.</returns>
        public static Uri GetUsersUri()
        {
            return new Uri($"Users", UriKind.Relative);
        }
    }
}
