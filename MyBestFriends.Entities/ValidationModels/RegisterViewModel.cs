using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBestFriends.Entities.ValidationModels
{
    public class RegisterViewModel
    {
        [DisplayName("Adı Soyadı"), 
         Required(ErrorMessage = "{0} alanı boş geçilemez."),
         StringLength(25,ErrorMessage ="{0} max. {1} karakter olmalıdır")]

        public string KullaniciAdiSoyadi { get; set; }

        [DisplayName("E-posta"),
         Required(ErrorMessage = "{0} alanı boş geçilemez."), 
         StringLength(70, ErrorMessage = "{0} max. {1} karakter olmalıdır"),
         EmailAddress(ErrorMessage ="{0} alanı için geçerli bir e-posta adresi giriniz")]

        public string Mail { get; set; }

        [DisplayName("Şifre"),
         Required(ErrorMessage = "{0} alanı boş geçilemez."), 
         DataType(DataType.Password),
         StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalıdır")]

        public string Sifre { get; set; }

        [DisplayName("Şifre Tekrarı"),
         Required(ErrorMessage = "{0} alanı boş geçilemez."),
         DataType(DataType.Password),
         StringLength(25, ErrorMessage = "{0} max. {1} karakter olmalıdır"),
         Compare("Sifre",ErrorMessage ="{0} ile {1} uyuşmuyor")]

        public string TekrarSifre { get; set; }

        [DisplayName("Telefon"),
        Required(ErrorMessage = "{0} alanı boş geçilemez."),
        DataType(DataType.Password),
        StringLength(11, ErrorMessage = "{0} max. {1} karakter olmalıdır"),
        Phone(ErrorMessage ="Geçersiz telefon alanı"),
        MinLength(11,ErrorMessage ="Min 11 karakter girebilirisiniz.")]

        public string Telefon { get; set; }

        
    }
}