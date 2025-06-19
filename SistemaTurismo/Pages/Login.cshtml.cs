using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace SistemaTurismo.Pages
{
    public class Login : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; }
        
        public string? UrlDeRetorno { get; set; }
        
        [TempData]
        public string? MensagemError { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Senha { get; set; }
        }

        public async Task OnGetAsync(string? returnUrl = null)
        {
            if (!string.IsNullOrEmpty(MensagemError))
            {
                ModelState.AddModelError(string.Empty, MensagemError);
            }
            UrlDeRetorno = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            UrlDeRetorno = returnUrl;

            if (ModelState.IsValid)
            {
                if (Input.Email == "admin@email.com" && Input.Senha == "123456")
                {
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, Input.Email),
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true, 
                        RedirectUri = Request.Host.Value
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme, 
                        new ClaimsPrincipal(claimsIdentity), 
                        authProperties);
                    
                    if (Url.IsLocalUrl(UrlDeRetorno))
                    {
                        return LocalRedirect(UrlDeRetorno);
                    }
                    else
                    {
                        return RedirectToPage("/Index");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Login inválido.");
                    return Page();
                }
            }
            return Page();
        }
    }
}
