using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.API.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string resourceName, int id):base($"Không tìm thấy {resourceName} với id = {id}")
        {
            
        }
    }
}