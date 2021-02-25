using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Models.Dtos
{
    public class TypeBreadDto
    {
        public TypeBreadDto(){}

        [Key]
        public int TypeBreadId { get; set; }

        [Display(Name = "نوع نان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(40, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Name { get; set; }


        //#region Relations
        //public List<BreadDto> Breads { get; set; }

        //#endregion
    }
}
