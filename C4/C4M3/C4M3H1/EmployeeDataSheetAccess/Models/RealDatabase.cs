using EmployeeDataSheetAccess.Interfaces;

namespace EmployeeDataSheetAccess.Models
{
    internal class RealDatabase : IDatabase
    {
        private readonly string _path = @"Resources\Database.txt";

        public virtual IEmployee GetEmployeeById(int id)
        {
            var line = File.ReadLines(_path).ElementAtOrDefault(id) ??
                throw new ArgumentOutOfRangeException(nameof(id), "Can not find employee by id");

            return new RealEmployee(this, line);
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
