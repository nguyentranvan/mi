﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MI.DBContext.Models;

public partial class TtestExam
{
    public Guid Id { get; set; }

    public Guid? TestUserId { get; set; }

    public Guid TestFormId { get; set; }

    public Guid UserId { get; set; }

    public string UserName { get; set; }

    public string DisplayName { get; set; }

    public Guid? OrganizeId { get; set; }

    public string OrganizeName { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public int StatusId { get; set; }

    public decimal? TotalMark { get; set; }

    public int? TotalQuestionTrue { get; set; }

    public int? TotalQuestionFalse { get; set; }

    public int? TotalQuestionNotAnswer { get; set; }

    public string ExamData { get; set; }

    public Guid CreatedUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdatedDate { get; set; }

    public Guid LastUpdatedUserId { get; set; }
}