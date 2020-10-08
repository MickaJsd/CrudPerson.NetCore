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

        public string OriginalPath { get; set; }
        public string OriginalQueryString { get; set; }

        public bool HasOriginalPath  => !string.IsNullOrWhiteSpace(this.OriginalPath);

        public string GetFormatedOriginalPath()
        {
            if (string.IsNullOrWhiteSpace(this.OriginalPath))
            {
                return string.Empty;
            }
            if (string.IsNullOrWhiteSpace(this.OriginalQueryString))
            {
                return this.OriginalPath;
            }
            return $"{this.OriginalPath}{this.OriginalQueryString}";
        }
    }
}
