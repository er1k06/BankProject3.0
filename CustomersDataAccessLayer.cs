using System;
using System.Collections.Generic;
using ErikBank.Entities;
using ErikBank.Exceptions;
using ErikBank.DataAccess.DALContracts;
using System.ComponentModel;

namespace ErikBank.DataAccess
{
    /// <summary>
    /// Represents DAL for bank customers
    /// </summary>
    public class CustomersDataAccessLayer:ICustomersDataAccessLayer
    {
        #region Fields
        private static List<Customer> _customers;
        #endregion


        #region 
        static CustomersDataAccessLayer()
        {
            _customers = new List<Customer>();
        }
        #endregion
        #region Properties
        /// <summary>
        /// Represents source customers collection 
        /// </summary>
        private static List<Customer> Customers
        {
            set=> _customers = value;
            get => _customers;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>Customers list</returns>
        public List<Customer>GetCustomers()
        {
            try
            {
                List<Customer> customersList = new List<Customer>();
                Customers.ForEach(Item => customersList.Add(Item.Clone() as Customer));
                return customersList;
            }
            catch(CustomerException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
            
        }
        /// <summary>
        /// returns list of customers that are matching with specified criteria 
        /// </summary>
        /// <param name="predicate">Lambda expression with condition </param>
        /// <returns>List of matching customers</returns>
        public List<Customer>GetCustomersByCondition(Predicate<Customer>predicate)
        {
            try
            {
                //create a new customers list
                List<Customer> customersList = new List<Customer>();

                //filter the collection
                List<Customer> filteredCustomers = Customers.FindAll(predicate);

                //copy all customers from the source collection into newCustomers list 
                filteredCustomers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch(CustomerException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
           
           

        }

        /// <summary>
        /// Adds a new customer to the existing list 
        /// </summary>
        /// <param name="customer">Customer object to add</param>
        /// <returns>Returns Guid of newly created customer</returns>
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                //generate new Guid
                customer.CustomerID = Guid.NewGuid();
                //add customer 
                Customers.Add(customer);
                return customer.CustomerID;
            }
            catch(CustomerException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
           
        }
        /// <summary>
        /// Updating an existing customer's details 
        /// </summary>
        /// <param name="customer">Customer objectwith updated details</param>
        /// <returns>Determines whether the customer is updated or not</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                //find existing customer by CustomerID
                Customer existingCustomer = Customers.Find(item => item.CustomerID == customer.CustomerID);

                //update all details of customer 
                if (existingCustomer != null)
                {
                    existingCustomer.CustomerCode = customer.CustomerCode;
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.Landmark = customer.Landmark;
                    existingCustomer.City = customer.City;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Mobile = customer.Mobile;
                    return true;//indicates the customer is updated 

                }
                else
                {
                    return false;//indicates no object is updated
                }

            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
           
        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                if (Customers.RemoveAll(item => item.CustomerID == customerID) > 0)
                {
                    return true;//indicates one or more customers are deleted 

                }
                else
                {
                    return false;//indicates no customer is deleted 
                }
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        #endregion


    }
}
