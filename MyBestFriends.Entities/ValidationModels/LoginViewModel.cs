using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBestFriends.Entities.ValidationModels
{
    public class LoginViewModel
    {
        [DisplayName("E-mail"),
         Required(ErrorMessage = "{0} alanı boş geçilemez."),
         StringLength(70, ErrorMessage = "{0} max. {1} karakter olmalıdır"),
         EmailAddress(ErrorMessage = "{0} alanı için geçerli bir e-posta adresi giriniz")]

        public string Mail { get; set; }

        [DisplayName("Şifre"), 
         Required(ErrorMessage = "{0} alanı boş geçilemez."),
         DataType(DataType.Password), 
         StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalıdır")]

        public string Sifre { get; set; }
    }
}