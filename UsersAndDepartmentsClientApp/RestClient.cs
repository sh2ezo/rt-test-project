using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UsersAndDepartmentsModel;

namespace UsersAndDepartmentsClientApp
{
    internal class RestClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Creates an instance of the <see cref="RestClient"/>.
        /// </summary>
        /// <param name="httpClient">Instance of the <see cref="HttpClient"/> used to make requests.</param>
        public RestClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Gets all departments.
        /// </summary>
        /// <returns>List of departments.</returns>
        public async Task<List<Department>> GetDepartmentsAsync()
        {
            using var response = await _httpClient
                .GetAsync(UriSource.GetDepartmentsUri())
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await DeserializeResponseAsync<List<Department>>(response)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Get users of the department.
        /// </summary>
        /// <param name="departmentId">Unique identifier of the department.</param>
        /// <returns>List of users.</returns>
        public async Task<List<User>> GetDepartmentUsersAsync(int departmentId)
        {
            using var response = await _httpClient
                .GetAsync(UriSource.GetDepartmentUsersListUri(departmentId))
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await DeserializeResponseAsync<List<User>>(response)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Creates new department.
        /// </summary>
        /// <param name="title">Title of the department.</param>
        /// <returns>Department.</returns>
        public async Task<Department> CreateDepartmentAsync(string title)
        {
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "title", title },
            });

            using var response = await _httpClient.PostAsync(UriSource.GetDepartmentsUri(), content)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await DeserializeResponseAsync<Department>(response)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <param name="fullName">Name of the user.</param>
        /// <param name="departmentId">Unique identifier of the department user will belong to.</param>
        /// <returns>User.</returns>
        public async Task<User> CreateUserAsync(string fullName, int departmentId)
        {
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "fullName", fullName },
                { "departmentId", departmentId.ToString() },
            });

            using var response = await _httpClient.PostAsync(UriSource.GetUsersUri(), content)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await DeserializeResponseAsync<User>(response)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Edits the department.
        /// </summary>
        /// <param name="departmentId">Unique identifier of the department.</param>
        /// <param name="title">New title of the department.</param>
        /// <returns>Department.</returns>
        public async Task<Department> EditDepartmentAsync(int departmentId, string title)
        {
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "title", title },
            });

            using var response = await _httpClient.PutAsync(UriSource.GetDepartmentUri(departmentId), content)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return await DeserializeResponseAsync<Department>(response)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// Deletes department.
        /// </summary>
        /// <param name="departmentId">Unique identifier of the department.</param>
        public async Task DeleteDepartmentAsync(int departmentId)
        {
            using var response = await _httpClient.DeleteAsync(UriSource.GetDepartmentUri(departmentId))
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Moves user to another department.
        /// </summary>
        /// <param name="userId">Unique identifier of the user.</param>
        /// <param name="departmentId">Unique identifier of the department.</param>
        public async Task MoveUserAsync(int userId, int departmentId)
        {
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "ids", userId.ToString() },
            });

            using var response = await _httpClient.PutAsync(UriSource.GetDepartmentUsersUri(departmentId), content)
                .ConfigureAwait(false);

            response.EnsureSuccessStatusCode();
        }

        private async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage response)
        {
            if (response.Content == null)
            {
                return default;
            }

            var jsonText = await response.Content
                .ReadAsStringAsync()
                .ConfigureAwait(false);

            return JsonSerializer.Deserialize<T>(jsonText);
        }
    }
}
