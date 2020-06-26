using Project.Repositories.Abstract;
using System;

namespace Project.Model
{
    public class Referral : IIdentifiable<long>
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }

        public Referral() { }

        public Referral(DateTime date, string type)
        {
            Date = date;
            Type = type;
        }
        public Referral(long id, DateTime date, string type)
        {
            Id = id;
            Date = date;
            Type = type;
        }

        public long GetId() => Id;

        public void SetId(long id) => Id = id;
    }
}