using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Models.Dtos
{
    public class ImageDto
    {
        public ImageDto(){}

        [Key]
        public int ImageId { get; set; }

        public int BreadId { get; set; }
        public string ImageFile { get; set; }

        //#region relations
        //public BreadDto Bread { get; set; }
        //#endregion
    }
}
