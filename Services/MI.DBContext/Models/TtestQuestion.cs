﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MI.DBContext.Models;

public partial class TtestQuestion
{
    public Guid Id { get; set; }

    public Guid CateId { get; set; }

    public string Code { get; set; }

    public string Question { get; set; }

    public int TypeId { get; set; }

    public int LevelId { get; set; }

    public int Mark { get; set; }

    /// <summary>
    /// Gợi ý
    /// </summary>
    public string Suggest { get; set; }

    public string MediaUrl { get; set; }

    public int IdIdentity { get; set; }

    public Guid CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public Guid LastUpdatedUserId { get; set; }
}