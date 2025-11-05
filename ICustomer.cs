using System;

namespace ErikBank.Entities.Contracts
{
    /// <summary>
    /// Represends interface of customer entity
    /// </summary>
    public interface ICustomer
    {
        #region Properties
        Guid CustomerID { get; set; }
        long CustomerCode { get; set; }
        string CustomerName { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string Landmark { get; set; }
        string Country { get; set; }
        string Mobile { get; set; }
        #endregion


    }

}