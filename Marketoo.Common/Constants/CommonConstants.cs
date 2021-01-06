using System;
using System.Collections.Generic;
using System.Text;

namespace Marketoo.Common.Constants
{
    public class CommonConstants
    {
        public enum EntityStatus
        {
            NoAction = 0,
            Add = 1,
            Update = 2,
            Delete = 3
        }
        public enum ProductStatus
        {
            Default = 0,
            InitiateQuery = 1,
            Processing = 2,
            Completed = 3
        }
    }
}
