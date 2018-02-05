using System.Collections.Generic;

namespace Common
{
    public class Constants
    {
        public const string FundAPIUrl = "http://localhost:61205";
        public const string AssetAPIUrl = "http://localhost:61301";
    }

    public class Result<T>
    {
        public string Type { get; set; }
        public T Data { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public int Page { get; set; }
    }

    public class Search
    {
        public PageSetting Paging { get; set; }
        public SortSettings Sorting { get; set; }
        public SortSettings Grouping { get; set; }
        public FilterSettings Filter { get; set; }
        public PropertiesCategory PropertiesCategory { get; set; }
    }

    //Might need to be expanded to handle multi-column sort
    public class SortSettings
    {
        public string ColumnName { get; set; }
        public bool IsDescending { get; set; }
    }

    public class PageSetting
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }

    public class FilterSettings
    {
        public List<int> Ids { get; set; }
        public bool ExcludeIds { get; set; }
        public string SearchString { get; set; }
    }

    //Defines which properties to bring back, this should help eliminate some waste in the size of the return
    public enum PropertiesCategory
    {
        All = 1,
        Default = 2,
        ID = 3,
        Name = 4
    }
}
