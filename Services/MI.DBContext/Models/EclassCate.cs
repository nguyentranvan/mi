﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MI.DBContext.Models;

public partial class EClassCate
{
    public Guid Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public Guid ParentId { get; set; }

    public int CateType { get; set; }

    public int? OrderNum { get; set; }

    public Guid CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public Guid LastUpdatedUserId { get; set; }
}
