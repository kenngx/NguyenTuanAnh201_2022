using System;
using System.ComponentModel.DataAnnotations;

namespace NguyenTuanAnh2022201
{
    public class NTA0201
    {
        [Key]
        [varchar(20)]
        [required]
        [Display(Name ="Mã sinh viên")]
        public string NTAId { get; set; }
        [nvarchar(50)]
        [Required(ErrorMessage ="Tên không được để trống")] 
        [Display(Name ="Tên sinh viên")]
        public string NTAName { get; set; }
        [required]
        [Display(Name ="Giới tính")]
        public Boolean NTAGender { get; set; }
    }
}