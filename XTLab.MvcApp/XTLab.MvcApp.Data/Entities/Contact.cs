using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XTLab.MvcApp.Infrastructure.SharedKernel;

namespace XTLab.MvcApp.Data.Entities;

public class Contact : DomainEntity<int>
{

    public Contact(string fullName, string email, DateTime dateSent, string message, string phone = null)
    {
        FullName = fullName;
        Email = email;
        DateSent = dateSent;
        Message = message;
        Phone = phone;
    }

    [Column(TypeName = "nvarchar")]
    [StringLength(50)]
    [Required(ErrorMessage = "Phải nhập  {0}")]
    [Display(Name = "Họ Tên")]
    public string FullName { get; set; }


    [Required(ErrorMessage = "Phải nhập  {0}")]
    [StringLength(100)]
    [EmailAddress(ErrorMessage = "Phải là địa chỉ email")]
    [Display(Name = "Địa chỉ email")]
    public string Email { get; set; }

    public DateTime DateSent { get; set; }

    [Display(Name = "Nội dung")]
    public string Message { get; set; }

    [StringLength(50)]
    [Phone(ErrorMessage = "Phải là số diện thoại")]
    [Display(Name = "Số điện thoại")]
    public string Phone { get; set; }
}
