using App.DatabaseModels;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Services
{
    public class EmployeeService
    {
        private readonly IMongoCollection<Employee> _employees;

        public EmployeeService(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _employees = database.GetCollection<Employee>(collectionName);
        }

        public List<Employee> Get()
        {
            return _employees.Find(Employee => true).ToList();
        }

        public Employee Get(string id)
        {
            return _employees.Find<Employee>(e => e.Id.Equals(id)).FirstOrDefault();
        }

        public Employee Create(Employee employee)
        {
            _employees.InsertOne(employee);
            return employee;
        }

        public void Update(string id, Employee employee)
        {
            _employees.ReplaceOne(book => book.Id == id, employee);
        }

        public void Delete(Employee employee)
        {
            _employees.DeleteOne(book => book.Id == employee.Id);
        }

        public void Delete(string id)
        {
            _employees.DeleteOne(book => book.Id == id);
        }
    }
}
