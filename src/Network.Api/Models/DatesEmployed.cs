using CSharpFunctionalExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Network.Api.Models
{
    [Owned]
    public class DatesEmployed : ValueObject
    {
        [JsonProperty]
        public DateTime StartDate { get; private set; }
        [JsonProperty]
        public DateTime EndDate { get; private set; }
        public int Days => (EndDate.Date - StartDate.Date).Days;
        public int Hours => (int)(EndDate - StartDate).TotalHours;

        protected DatesEmployed()
        {

        }

        private DatesEmployed(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StartDate;
            yield return EndDate;
        }

        public static Result<DatesEmployed> Create(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                return Result.Failure<DatesEmployed>("Start Date should be less than End Date");

            return Result.Success(new DatesEmployed(startDate, endDate));
        }

        public bool Overlap(DatesEmployed dateRange)
        {
            _ = dateRange ?? throw new ArgumentNullException(nameof(dateRange));

            return StartDate < dateRange.EndDate && dateRange.StartDate < EndDate;
        }
    }
}