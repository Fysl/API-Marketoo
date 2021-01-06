using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Marketoo.Common.Constants.CommonConstants;

namespace Marketoo.WebAPI.API.v1.Models.Shared
{
    public class Document
    {
        public string DocumentId { get; set; }
        public string DocumentType { get; set; }
        public string DocumentUri { get; set; }
        public bool IsDocumentVerified { get; set; }
        public long? DocumentExpiryDate { get; set; }
        public bool IsActive { get; set; }
        public EntityStatus Status { get; set; }
    }
}
