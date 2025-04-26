using System;

namespace Tedu.KnowledgeSpace.ViewModels;

public class Pagination<T>
{
    public List<T> Items { get; set; }

    public int TotalRecords { get; set; }
}