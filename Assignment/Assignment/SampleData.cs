using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {

        // 1.
        public IEnumerable<string> CsvRows
            => File.ReadAllLines("People.csv").Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            List<string> uniqueSortedStates = new();

            foreach (string row in CsvRows)
            {
                string[] splitRow = row.Split(',');
                if (!uniqueSortedStates.Contains(splitRow[6])) uniqueSortedStates.Add(splitRow[6]);
            }
            uniqueSortedStates.Sort();
            return uniqueSortedStates;
        }


        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            string[] uniqueSortedStates = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
            string uniqueStatesSorted = string.Join(",", uniqueSortedStates);
            return uniqueStatesSorted;
        }

        // 4.
        public IEnumerable<IPerson> People
            => CsvRows.Select(row => Person.ParseRow(row));


        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}