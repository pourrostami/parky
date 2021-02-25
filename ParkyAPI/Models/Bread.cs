using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Models
{
    public class Bread
    {
        public Bread(){}

        [Key]
        public int BreadId { get; set; }

        public int TypeBreadId { get; set; }

        [Display(Name = "نام نان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(40, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Name { get; set; }


        #region Relations

        public TypeBread TypeBread { get; set; }
        public List<Image> Images { get; set; }

        #endregion
    }
}
