using SampleAssignment.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace SampleAssignment.Implement
{
    public class SampleData
    {
        public SampleData()
        {

        }

        public List<Employee> GetAllEmployee(string path)
        {
            Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
            var values = File.ReadAllLines(path)
                                          .Skip(1)
                                          .Select(v => Employee.FromCsv(v))
                                          .ToList();
            return values;
        }

        public List<Employee> SearchData(string keyWork, string path)
        {
            var lowKeyWork = keyWork.ToLower();
            var listData = GetAllEmployee(path);
            var searchResult = listData.Where(x => x.first_name.ToLower().Contains(keyWork) || x.last_name.ToLower().Contains(keyWork)).ToList();

            return searchResult;
        }
        public List<Employee> PagingEmployee(int fromIndex, int toIndex, string path)
        {
            var data = GetAllEmployee(path);
            int i = 1;
            foreach (var item in data)
            {
                item.index = i;
                i++;
            }
            var dataIndex = data.Where(x => x.index >= fromIndex && x.index <= toIndex).ToList();
            return dataIndex;
        }

        public List<Partition> Partition(int numofItemList, int numOfRecordPerPage)
        {
            int maxIndex = 0;
            int minIndex = 1;
            int index = 0;
            var listPartition = new List<Partition>();
            while(maxIndex < numofItemList)
            {
                minIndex = maxIndex + 1;
                maxIndex = maxIndex + numOfRecordPerPage;
                index = ++index;
                listPartition.Add(new Partition
                {
                    Index = index,
                    FromIndex = minIndex,
                    ToIndex = maxIndex
                });
            }
            return listPartition;
        }


    }
}