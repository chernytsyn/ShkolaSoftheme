using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureSql_Chernytsyn
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new InternshipDB_ChernytsynEntities())
            {
                var students = context.Students;

                foreach (Students s in students)
                {
                    Console.WriteLine($"ID:{s.StudentID}, Name:{s.StudentName}");
                }
            }

            Console.ReadLine();
            
        }
    }
}
