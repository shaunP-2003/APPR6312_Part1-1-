using Microsoft.EntityFrameworkCore;
using APPR6312_Part1_1_.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace APPR6312_Part1_1_.Data
{
    public class DAFAppDbContext : IdentityDbContext<IdentityUser>
    {
        public DAFAppDbContext(DbContextOptions<DAFAppDbContext> options) : base(options)
        {
            
        }

        
    }
}

//The following method was taken from youtube
// Author: Digtal TechJoint
//Link: https://youtu.be/ghzvSROMo_M?si=Y1YzZVwhciU1dcUm