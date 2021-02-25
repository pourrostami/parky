using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Models.Dtos
{
    public class NationalParkDto
    {
        [Key]
        public int NationalParkId { get; set; }

        [Display(Name="نام پارک")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(40, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Name { get; set; }

        [Display(Name = "نام استان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(40, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string State { get; set; }

        [Display(Name="تاریخ ساخت")]
        public DateTime Created { get; set; }

        [Display(Name ="تاریخ افتتاح")]
        public DateTime Established { get; set; }
    }
}
