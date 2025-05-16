using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
	// Hàm in số kèm theo thông điệp
	static void PrintNumber(string message)
	{
		for (int i = 1; i <= 5; i++)
		{
			Console.WriteLine($"{message}:{i}");
			Thread.Sleep(1000); // Tạm dừng 1 giây giữa mỗi lần in
		}
	}

	static void Main()
	{
		Thread.CurrentThread.Name = "Main"; // Đặt tên cho thread chính

		// Tạo task bằng biểu thức lambda
		Task task01 = new Task(() => PrintNumber("Task 01"));
		task01.Start();

		// Tạo và chạy task bằng delegate
		Task task02 = Task.Run(delegate {
			PrintNumber("Task 02");
		});

		// Tạo task bằng Action delegate
		Task task03 = new Task(new Action(() => {
			PrintNumber("Task 03");
		}));
		task03.Start();

		// In tên thread hiện tại
		Console.WriteLine($"Thread '{Thread.CurrentThread.Name}'");

		Console.ReadKey(); // Dừng màn hình chờ người dùng bấm phím
	}
}
