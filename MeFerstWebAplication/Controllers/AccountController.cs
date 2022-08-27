using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MeFerstWebAplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MeFerstWebAplication.Models.UserModel;
using Microsoft.AspNetCore.Identity;


namespace MeFerstWebAplication.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationContext db;
        IWebHostEnvironment _appEnvironment;
        public AccountController(ApplicationContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Вход на аккаунт
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                //User? user = await db.DbUser.FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);

                User? user = await db.DbUser
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);

                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <param name="uploadedFile"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model, IFormFile uploadedFile)
        {
            string path;
            string age_user;
            if (uploadedFile == null)
            {
                path = "/User/BlackSqaut.png";
            }
            else
            {
                // путь к папке Files
                path = "/User/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
            }
            if (model.Age != null)
            {
                age_user = Convert.ToString(DateTime.Now.Year - Convert.ToInt32(model.Age.Substring(0, model.Age.Length - 6)));
            }
            else
            {
                age_user = "Undefinitely";
            }
                // if (ModelState.IsValid)
            {
                User? user = await db.DbUser.FirstOrDefaultAsync(u => u.Login == model.Login);
                // Добавление user в геристарции
                if (user == null)
                {
                    // добавляем пользователя в бд
                    user = new User { 
                        Login = model.Login, 
                        Password = model.Password, 
                        Email = model.Email, 
                        Age = age_user, 
                        ImageUserUrl = path };

                    Role userRole = await db.Roles.FirstOrDefaultAsync(r => r.Name == "User");
                    if (userRole != null)
                        user.Role = userRole;

                    db.DbUser.Add(user);
                    await db.SaveChangesAsync();

                    await Authenticate(user); // аутентификация
                }
                else
                   ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                return RedirectToAction("Index", "Home");
            }
           // return View(model);
        }
        /// <summary>
        /// Авторизация пользователя в claim
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        /// <summary>
        /// Выход с аккаунта
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}