using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<RegisteredPerson> _userManager;

        public RegisterController(UserManager<RegisteredPerson> userManager)
        {
            _userManager = userManager;
        }

        public SelectList SelectBloodGroup()
        {
            List<BloodGroup> bloodGroups = new List<BloodGroup>();

            bloodGroups.Add(BloodGroup.AB_Minus);
            bloodGroups.Add(BloodGroup.AB_Plus);
            bloodGroups.Add(BloodGroup.O_Minus);
            bloodGroups.Add(BloodGroup.O_Plus);
            bloodGroups.Add(BloodGroup.A_Minus);
            bloodGroups.Add(BloodGroup.A_Plus);
            bloodGroups.Add(BloodGroup.B_Minus);
            bloodGroups.Add(BloodGroup.B_Plus);

            var models = bloodGroups.Select(group => new BloodGroupDropdownModel
            {
                Name = group.ToString(),
                Id = (int)group
            });

            var selectedBloodGroups = new SelectList(models, "Id", "Name");

            return selectedBloodGroups;
        }


        public ActionResult Register()
        {
            ViewBag.Groups = SelectBloodGroup();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisteredPerson model)
        {
            if (ModelState.IsValid)
            {
                var user = new RegisteredPerson
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BloodGroup = model.BloodGroup,
                    UserName = model.UserName,
                    Email = model.Email
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    return  RedirectToAction("Index","Home");
                }
            }

            //stex arden karas dbi heti gorcery anes , qces db kam stugumner anes
            //hima asem inch arim 
            //nax en register viewn du grel eyr account areai mej, u aysinqn home controlleric tenc prosty vor kanches return View inqy chi gna yndex
            //dra hamar anuny poxeci dreci register, en myus registeri mejinnery qceci es meki mej, mekel miatel register action sarqeci
            //bayc es meky post atributov, isk et nshanakuma vor en formic vor submity kancchvi kga posti mej kmtni
            //stex el qo modely arden celikom karas stanas, yndex validacianer anes, inchvor mas ka vor chhaskacar?
            return RedirectToAction("Index","Home");
        }
    }
}