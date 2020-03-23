using System;

namespace EmployeePayroll
{
    public class DatedDocument
    {
        public DateTime Date
        { get; protected set; }

        public DatedDocument(DateTime date)
        {
            this.Date = date;
        }

        public DatedDocument(int[] date)
        {
            if (date.Length != 3) {
                throw new NotSupportedException("The date tuple needs to be length 3: {year, month, day}.");
            } else {
                this.Date = new DateTime(date[0], date[1], date[2]);
            }
        }
    }
}