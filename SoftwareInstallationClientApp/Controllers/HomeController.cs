using SoftwareInstallationClientApp.Models;
using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareInstallationClientApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        int countOnPage = 3;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(APIClient.GetRequest<List<OrderViewModel>>($"api/main/getorders?clientId={Program.Client.Id}"));
        }
        [HttpGet]
        public IActionResult Privacy()
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View(Program.Client);
        }
        [HttpPost]
        public void Privacy(string login, string password, string fio)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(fio))
            {
                APIClient.PostRequest("api/client/updatedata", new ClientBindingModel
                {
                    Id = Program.Client.Id,
                    FIO = fio,
                    Login = login,
                    Password = password
                });
                Program.Client.FIO = fio;
                Program.Client.Login = login;
                Program.Client.Password = password;
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Enter()
        {
            return View();
        }

        [HttpPost]
        public void Enter(string login, string password)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                Program.Client = APIClient.GetRequest<ClientViewModel>($"api/client/login?login={login}&password={password}");
                if (Program.Client == null)
                {
                    throw new Exception("Неверный логин/пароль");
                }
                Response.Redirect("Index");
                return;
            }
            throw new Exception("Введите логин, пароль");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public void Register(string login, string password, string fio)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(fio))
            {
                APIClient.PostRequest("api/client/register", new ClientBindingModel
                {
                    FIO = fio,
                    Login = login,
                    Password = password
                });
                Response.Redirect("Enter");
                return;
            }
            throw new Exception("Введите логин, пароль и ФИО");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Packages = APIClient.GetRequest<List<PackageViewModel>>("api/main/getpackagelist");
            return View();
        }

        [HttpPost]
        public void Create(int package, int count, decimal sum)
        {
            if (count == 0 || sum == 0)
            {
                return;
            }
            APIClient.PostRequest("api/main/createorder", new CreateOrderBindingModel
            {
                ClientId = Program.Client.Id,
                PackageId = package,
                Count = count,
                Sum = sum
            });
            Response.Redirect("Index");
        }

        [HttpPost]
        public decimal Calc(decimal count, int package)
        {
            PackageViewModel pack = APIClient.GetRequest<PackageViewModel>($"api/main/getpackage?packageId={package}");
            return count * pack.Price;
        }
        [HttpGet]
        public IActionResult MessageInfo(int pageNumber)
        {
            if (Program.Client == null)
            {
                return Redirect("~/Home/Enter");
            }

            List<MessageInfoViewModel> model = new List<MessageInfoViewModel>();
            if (pageNumber > 0)
            {
                model = APIClient.GetRequest<List<MessageInfoViewModel>>($"api/client/GetClientsMessagesInfo?clientId={Program.Client.Id}&pageNumber={pageNumber}");
            }

            if (model.Count == 0 && Program.PageNumber != 0)
            {
                model = APIClient.GetRequest<List<MessageInfoViewModel>>($"api/client/GetClientsMessagesInfo?clientId={Program.Client.Id}&pageNumber={Program.PageNumber}");
            }
            else
            {
                Program.PageNumber = pageNumber;
            }
            ViewBag.Id = Program.PageNumber;
            return View(model);
        }

        [HttpGet]
        public IActionResult NextMailsPage()
        {
            return Redirect($"~/Home/MessageInfo?pageNumber={Program.PageNumber + 1}");
        }

        [HttpGet]
        public IActionResult PrevMailsPage()
        {
            if (Program.PageNumber > 1)
            {
                return Redirect($"~/Home/MessageInfo?pageNumber={Program.PageNumber - 1}");
            }
            return Redirect($"~/Home/MessageInfo?pageNumber={Program.PageNumber}");
        }
    }
}
