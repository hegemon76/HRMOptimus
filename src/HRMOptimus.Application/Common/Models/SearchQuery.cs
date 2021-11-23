using HRMOptimus.Domain.Enums;

namespace HRMOptimus.Application.Common.Models
{
    public class SearchQuery
    {
        public string SearchPhrase { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}