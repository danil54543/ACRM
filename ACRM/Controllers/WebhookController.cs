using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ACRM.Controllers
{
    [ApiController]
    [Route("api/webhook")]
    public class WebhookController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> ReceiveData()
        {
            using StreamReader reader = new(Request.Body, Encoding.UTF8);
            string requestBody = await reader.ReadToEndAsync();

            // Здесь вы можете обработать полученные данные
            // Например, можно преобразовать их в объект или отправить их в базу данных

            return Ok(); // Возвращаем HTTP 200 OK
        }
    }
}
