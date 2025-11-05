using ErikBank.BusinessLogic.BALContracts;
using ErikBank.Configuration;
using ErikBank.DataAccess;
using ErikBank.DataAccess.DALContracts;
using ErikBank.Entities;
using ErikBank.Entities.Contracts;
using ErikBank.Exceptions;
using System;
using System.Collections.Generic;

namespace ErikBank.BusinessLogic
{
    /// <summary>
    /// Represents customers business logic
    /// </summary>
    public class CustomersBusiness : ICustomersBusinessLogicLayer
    {
        #region Private Fields
        private ICustomersDataAccessLayer _customersDataAccessLAyer;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor that initializes  CustomersDataAccessLayer
        /// </summary>
        public CustomersBusiness()
        {
            _customersDataAccessLAyer = new CustomersDataAccessLayer();
        }
        #endregion

        #region Properties
        private ICustomersDataAccessLayer CustomersDataAccessLayer
        {
            set=> _customersDataAccessLAyer= value;
            get => _customersDataAccessLAyer;
        }
        #endregion

        #region Methods
        public List<Customer> GetCustomers()
        {
            try
            {
                return CustomersDataAccessLayer.GetCustomers();
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
        /// <summary>
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda expression that contains conditions to check</param>
        /// <returns>The list of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                return CustomersDataAccessLayer.GetCustomersByCondition(predicate);
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
            

/// <summary>
/// Adds a new customer to the existing customers list
/// </summary>
/// <param name="customer">The customer object to add</param>
/// <returns>Returns true, that indicates the customer is added successfully </returns>
public Guid AddCustomer(Customer customer)
        {
            try
            {
                List<Customer> allCustomers = CustomersDataAccessLayer.GetCustomers();
                long maxCustCode = 0;
                foreach(var item in  allCustomers)
                {
                    if (item.CustomerCode>maxCustCode)
                    {
                        maxCustCode = item.CustomerCode;
                    }
                }
                if (allCustomers.Count>=1)
                {
                    customer.CustomerCode=maxCustCode+1;
                }
                else
                {
                    customer.CustomerCode = ErikBank.Configuration.Settings.BaseCustomerNo + 1;
                }

                    return CustomersDataAccessLayer.AddCustomer(customer);
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
        /// <summary>
        /// Deletes an existing customer
        /// </summary>
        /// <param name="customerID">CustomerID to delete</param>
        /// <returns>Returns true, that indicates the customer is deleted successfully </returns>
        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                return CustomersDataAccessLayer.DeleteCustomer(customerID);

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

        /// <summary>
        /// Updates an existing customer
        /// </summary>
        /// <param name="customer">Customer object that contains customer details to update </param>
        /// <returns>Returns true,that indicates the customer is updated successfully</returns>
        public bool UpdateCustomer(Customer customer)
        {
            try
            {
               return CustomersDataAccessLayer.UpdateCustomer(customer);
                
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