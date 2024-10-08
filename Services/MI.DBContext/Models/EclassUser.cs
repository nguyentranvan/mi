﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MI.DBContext.Models;

public partial class EClassUser
{
    public Guid Id { get; set; }

    public Guid ClassId { get; set; }

    public Guid UserId { get; set; }

    public string UserName { get; set; }

    public string DisplayName { get; set; }

    public Guid? OrganizeId { get; set; }

    public string OrganizeName { get; set; }

    public DateTime RegistrationTime { get; set; }

    public bool IsApproved { get; set; }

    public DateTime? ApprovedTime { get; set; }

    public DateTime? LastActivityTime { get; set; }

    public DateTime? FinishedTime { get; set; }

    public bool IsFinished { get; set; }

    public decimal? TotalTime { get; set; }

    public decimal? TotalScore { get; set; }

    public Guid CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public Guid LastUpdatedUserId { get; set; }
}