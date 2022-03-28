using System;
using System.ComponentModel.DataAnnotations;

namespace NguyenTuanAnh2022201
{
    public class Person
    {
        [Key]
        [varchar(20)]
        [required]
        [Display(Name ="Mã người")]
        public string PersonId { get; set; }
        [nvarchar(50)]
        [Required(ErrorMessage ="Tên không được để trống")] 
        [Display(Name ="Tên người")]
        public string PersonName { get; set; }
    }
}