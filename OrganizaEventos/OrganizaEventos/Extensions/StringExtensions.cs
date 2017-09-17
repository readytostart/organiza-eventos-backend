using System.Collections.Generic;
using System.Linq;

namespace OrganizaEventosApi.Extensions {
    public static class StringExtensions {
        public static List<string> SplitCsv(this string csvList, bool nullOrWhitespaceInputReturnsNull = false) {
            if (string.IsNullOrWhiteSpace(csvList))
                return nullOrWhitespaceInputReturnsNull ? null : new List<string>();

            return csvList
                .TrimEnd(',')
                .Split(',')
                .AsEnumerable<string>()
                .Select(s => s.Trim())
                .ToList();
        }
    }
}