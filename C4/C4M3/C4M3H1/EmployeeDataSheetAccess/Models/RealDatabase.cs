using EmployeeDataSheetAccess.Interfaces;

namespace EmployeeDataSheetAccess.Models
{
    internal class RealDatabase : IDatabase
    {
        private readonly string _path = @"Resources\Database.txt";

        private readonly Dictionary<int, IEmployee> _data = new();

        public virtual IEmployee GetEmployeeById(int id)
        {
            if (_data.TryGetValue(id, out var employee))
            {
                return employee;
            }
            else
            {
                var line = File.ReadLines(_path).ElementAtOrDefault(id) ??
                    throw new ArgumentOutOfRangeException(nameof(id), "Can not find employee by id");

                var result = new RealEmployee(this, line);
                _data.Add(id, result);

                return result;
            }
        }

        //public IEmployee GetEmployeeById(int id)
        //{
        //    var line = string.Empty;

        //    using (var sr = new StreamReader(this._path))
        //    {
        //        var i = 0;

        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            if (i == 0)
        //                break;
        //            else
        //                i++;
        //        }

        //        sr.Close();
        //    }

        //    if (line == null)
        //    {
        //        // 該員工不存在
        //        throw new ArgumentException();
        //    }

        //    return RealEmplyee.ConvertRealEmplyee(line);
        //}
    }
}
