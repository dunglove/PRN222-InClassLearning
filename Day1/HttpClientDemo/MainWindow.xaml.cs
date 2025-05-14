using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HttpClientDemo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

	// Khởi tạo HttpClient dùng để gửi yêu cầu HTTP
	readonly HttpClient client = new HttpClient();

	// Sự kiện khi nhấn nút "Close"
	private void btnClose_Click(object sender, RoutedEventArgs e)
	{
		Close();
	}

	// Sự kiện khi nhấn nút "Clear" để xoá nội dung
	private void btnClear_Click(object sender, RoutedEventArgs e)
	{
		txtContent.Text = string.Empty;
	}

	// Sự kiện khi nhấn nút "View HTML" (tải nội dung HTML từ URL)
	private async void btnViewHTML_Click(object sender, RoutedEventArgs e)
	{
		string uri = txtURL.Text;

		// Gọi phương thức mạng bất đồng bộ trong khối try/catch
		try
		{
			string responseBody = await client.GetStringAsync(uri); // Gửi GET request
			txtContent.Text = responseBody.Trim(); // Hiển thị kết quả sau khi xoá khoảng trắng thừa
		}
		catch (HttpRequestException ex)
		{
			// Hiển thị thông báo lỗi nếu yêu cầu thất bại
			MessageBox.Show($"Message: {ex.Message}");
		}
	}
}