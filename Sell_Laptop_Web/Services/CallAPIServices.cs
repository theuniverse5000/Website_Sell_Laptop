using Newtonsoft.Json;

namespace Sell_Laptop_Web.Services
{
    public class CallAPIServices
    {
        public async Task<IEnumerable<T>> GetAll<T>(string apiUrl)
        {
            List<T> list = new List<T>();
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);
            // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Đọc từ string Json vừa thu được sang List<T>
            list = JsonConvert.DeserializeObject<List<T>>(apiData);
            return list;
        }
        public async Task<IEnumerable<T>> GetAlls<T>(string apiUrl)
        {
            List<T> list = new List<T>();
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);
            // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Đọc từ string Json vừa thu được sang List<T>
            list = JsonConvert.DeserializeObject<List<T>>(apiData);
            return list;
        }

    }
}
