using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPR6312_Part1_1_.Models.Views
{
    public class MonetaryDonoViewModel
    {
        public Guid MoneyDonationId { get; set; }
        public DateTime DonationDate { get; set; }
        public decimal Amount { get; set; }
        public string DonorName { get; set; }
    }
}
//The following method was taken from youtube
// Author: Sameer Saini
//Link: https://youtu.be/2Cp8Ti_f9Gk?si=ve2zdqpPaGJ2rfVO