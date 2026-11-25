using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyHocSinhLINQ
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} | Name: {Name} | Age: {Age}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Khởi tạo danh sách ít nhất 5 học sinh
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "An", Age = 16 },
                new Student { Id = 2, Name = "Bình", Age = 14 },
                new Student { Id = 3, Name = "Anh", Age = 18 },
                new Student { Id = 4, Name = "Cường", Age = 17 },
                new Student { Id = 5, Name = "Dũng", Age = 19 }
            };

            // In danh sách khởi tạo khi chạy chương trình
            Console.WriteLine("=== Danh sách học sinh khởi tạo ===");
            foreach (var s in students)
            {
                Console.WriteLine("  " + s);
            }

            // a. In toàn bộ danh sách học sinh bằng LINQ
            Console.WriteLine("\na. Toàn bộ danh sách học sinh:");
            var allStudents = students.Select(s => s).ToList();
            foreach (var s in allStudents)
            {
                Console.WriteLine("  " + s);
            }

            // b. Tìm và in ra danh sách các học sinh có tuổi từ 15 đến 18
            Console.WriteLine("\nb. Học sinh có tuổi từ 15 đến 18:");
            var age15To18 = students
                .Where(s => s.Age >= 15 && s.Age <= 18)
                .ToList();
            foreach (var s in age15To18)
            {
                Console.WriteLine("  " + s);
            }

            // c. Tìm và in ra học sinh có tên bắt đầu bằng chữ "A"
            Console.WriteLine("\nc. Học sinh có tên bắt đầu bằng chữ \"A\":");
            var nameStartsWithA = students
                .Where(s => s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase))
                .ToList();
            foreach (var s in nameStartsWithA)
            {
                Console.WriteLine("  " + s);
            }

            // d. Tính tổng tuổi của tất cả học sinh trong danh sách
            int totalAge = students.Sum(s => s.Age);
            Console.WriteLine($"\nd. Tổng tuổi của tất cả học sinh: {totalAge}");

            // e. Tìm và in ra học sinh có tuổi lớn nhất
            Console.WriteLine("\ne. Học sinh có tuổi lớn nhất:");
            if (students.Count > 0)
            {
                int maxAge = students.Max(s => s.Age);
                var oldestStudents = students
                    .Where(s => s.Age == maxAge)
                    .ToList();
                foreach (var s in oldestStudents)
                {
                    Console.WriteLine("  " + s);
                }
            }

            // f. Sắp xếp danh sách học sinh theo tuổi tăng dần và in ra
            Console.WriteLine("\nf. Danh sách học sinh sắp xếp theo tuổi tăng dần:");
            var sortedByAge = students
                .OrderBy(s => s.Age)
                .ToList();
            foreach (var s in sortedByAge)
            {
                Console.WriteLine("  " + s);
            }
        }
    }
}