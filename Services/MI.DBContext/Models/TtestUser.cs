﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MI.DBContext.Models;

public partial class TTestUser
{
    public Guid Id { get; set; }

    public Guid TestInfoId { get; set; }

    public Guid TestFormId { get; set; }

    public Guid UserId { get; set; }

    public string UserName { get; set; }

    public string DisplayName { get; set; }

    public Guid? OrganizeId { get; set; }

    public string OrganizeName { get; set; }

    public DateTime RegistrationTime { get; set; }

    public Guid CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public Guid LastUpdatedUserId { get; set; }
}