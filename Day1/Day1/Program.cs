using System.Net;

internal class Program
{
	static void Main(string[] args)
	{
		// Tạo một yêu cầu (request) đến URL.
		WebRequest request = WebRequest.Create("http://www.contoso.com/default.html");
		// Nếu máy chủ yêu cầu xác thực, thiết lập thông tin đăng nhập.
		request.Credentials = CredentialCache.DefaultCredentials;

		// Gửi yêu cầu và nhận phản hồi từ máy chủ.
		HttpWebResponse response = (HttpWebResponse)request.GetResponse();

		// Hiển thị trạng thái phản hồi.
		Console.WriteLine("Status: " + response.StatusDescription);
		Console.WriteLine(new string('*', 50));

		// Lấy luồng dữ liệu từ phản hồi.
		Stream dataStream = response.GetResponseStream();

		// Mở luồng bằng StreamReader để dễ đọc dữ liệu.
		StreamReader reader = new StreamReader(dataStream);

		// Đọc toàn bộ nội dung từ máy chủ.
		string responseFromServer = reader.ReadToEnd();

		// Hiển thị nội dung phản hồi.
		Console.WriteLine(responseFromServer);
		Console.WriteLine(new string('*', 50));

		// Đóng các luồng và phản hồi để giải phóng tài nguyên.
		reader.Close();
		dataStream.Close();
		response.Close();
	}
}