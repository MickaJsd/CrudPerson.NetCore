using System.Collections.Generic;
using System.Linq;

namespace CrudPerson.WebUI.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);

        public int? StatusCode { get; set; }

        public static IEnumerable<int> SupportedStatusCode => new int[] { 404, 500 };

        public bool StatusCodeIsSupported => this.StatusCode.HasValue && SupportedStatusCode.Contains(this.StatusCode.Value);
    }
}
