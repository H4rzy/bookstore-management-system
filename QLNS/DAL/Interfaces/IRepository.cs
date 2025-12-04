using System.Collections.Generic;

namespace QLNS.DAL.Interfaces
{
    /// <summary>
    /// Generic repository interface defining standard CRUD operations
    /// Follows Repository Pattern and Interface Segregation Principle
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Gets all entities from the database
        /// </summary>
        /// <returns>Collection of all entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets a single entity by its ID
        /// </summary>
        /// <param name="id">Entity ID</param>
        /// <returns>Entity or null if not found</returns>
        T GetById(string id);

        /// <summary>
        /// Adds a new entity to the database
        /// </summary>
        /// <param name="entity">Entity to add</param>
        /// <returns>True if successful, false otherwise</returns>
        bool Add(T entity);

        /// <summary>
        /// Updates an existing entity in the database
        /// </summary>
        /// <param name="entity">Entity to update</param>
        /// <returns>True if successful, false otherwise</returns>
        bool Update(T entity);

        /// <summary>
        /// Deletes an entity from the database
        /// </summary>
        /// <param name="id">ID of entity to delete</param>
        /// <returns>True if successful, false otherwise</returns>
        bool Delete(string id);
    }
}
