using C4M3H1.Interfaces;

namespace C4M3H1
{
    internal class RealDatabase : IDatabase
    {
        private readonly string _path = @"Database.txt";

        public virtual IEmployee GetEmployeeById(int id)
        {
            var line = File.ReadLines(this._path).ElementAtOrDefault(id);

            if (line == null)
            {
                // 該員工不存在
                throw new ArgumentException();
            }

            return new RealEmplyee(this, line);
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
