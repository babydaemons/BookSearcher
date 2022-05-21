using System.Collections.Generic;
using System.Data;

namespace BookSearcher
{
    public class MemoryRow : Dictionary<string, string>
    {
        const string primaryKey = "RowIndex";

        public int RowIndex
        {
            get
            {
                _ = int.TryParse(this[primaryKey], out int value);
                return value;
            }
            set
            {
                this[primaryKey] = value.ToString("D10");
            }
        }

        public DataRow WriteDataRow(int rowIndex, DataRow row)
        {
            int i = 0;
            foreach (var columName in Keys)
            {
                if (columName == primaryKey)
                {
                    row[i++] = rowIndex;
                }
                else
                {
                    row[i++] = this[columName];
                }
            }
            return row;
        }
    }
}
