using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class RolesModel
    {
        ApplicationDbContext context;
        public RolesModel()
        {
            context = new ApplicationDbContext();
        }
        public void Create(IdentityRole role)
        {

            role.Name = "Librarian";
            context.Roles.Add(role);
            role.Name = "Member";
            context.Roles.Add(role);
            context.SaveChanges();
        }
    }
}