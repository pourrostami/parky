using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Models
{
    public class Image
    {
        public Image(){}

        [Key]
        public int ImageId { get; set; }

        public int BreadId { get; set; }
        public string ImageFile { get; set; }

        #region relations
        public Bread Bread { get; set; }
        #endregion
    }
}
