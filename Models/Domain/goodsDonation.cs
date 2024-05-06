﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPR6312_Part1_1_.Models.Domain
{
        public class goodsDonation
        {
            [Key]
            public Guid goodDonationId { get; set; }
            public DateTime DonationDate { get; set; }
            public int NumberOfItems { get; set; }
            public string goodsCategory { get; set; }
            public string Description { get; set; }
            public string DonorName { get; set; }

            


    }


}


//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO