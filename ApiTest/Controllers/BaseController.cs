﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    public class BaseController : Controller
    {
    }
    public class Result<T>
    {
        public T Data { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
    }
    public interface IResult<T>
    {
        string Status { get; set; }
        string Message { get; set; }
        T Data { get; set; }
    }
    public class Search
    {
        public PageSetting Paging { get; set; }
        public SortSettings Sorting { get; set; }
        public SortSettings Grouping { get; set; }
        public FilterSettings Filter { get; set; }
        public PropertiesCategory PropertiesCategory { get; set; }
    }
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
    public enum PropertiesCategory
    {
        All = 1,
        Default = 2,
        ID = 3,
        Name = 4
    }
}
