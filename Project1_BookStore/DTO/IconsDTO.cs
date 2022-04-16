using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1_BookStore.DTO
{
    public class Icons : INotifyPropertyChanged
    {
        public string pathCloseBtn { get; set; } = "/Resource/Images/Icons/close.png";
        public string pathClosePressedBtn { get; set; } = "/Resource/Images/Icons/close-pressed.png";
        public string pathMaxBtn { get; set; } = "/Resource/Images/Icons/maximize.png";
        public string pathMaxPressedBtn { get; set; } = "/Resource/Images/Icons/maximize-pressed.png";
        public string pathMinBtn { get; set; } = "/Resource/Images/Icons/minimize.png";
        public string pathMinPressedBtn { get; set; } = "/Resource/Images/Icons/minimize-pressed.png";
        public string pathReDownBtn { get; set; } = "/Resource/Images/Icons/reDown.png";
        public string pathReDownPressedBtn { get; set; } = "/Resource/Images/Icons/reDown-pressed.png";
        public string logo { get; set; } = "/Resource/Images/Icons/logo_v2.png";
        public string upload { get; set; } = "/Resource/Images/Icons/upload.png";
        public string modify { get; set; } = "/Resource/Images/Icons/modify.png";
        public string plus { get; set; } = "/Resource/Images/Icons/plus-square.png";
        public string minus { get; set; } = "/Resource/Images/Icons/minus.png";
        public string arrow_left { get; set; } = "/Resource/Images/Icons/left-arrow.png";
        public string arrow_right { get; set; } = "/Resource/Images/Icons/right-arrow.png";
        public string setting { get; set; } = "/Resource/Images/Icons/info.png";
        public string bell { get; set; } = "/Resource/Images/Icons/bell.png";
        public string sign_out { get; set; } = "/Resource/Images/Icons/sign-out.png";
        public string export { get; set; } = "/Resource/Images/Icons/export.png";
        public string avatar { get; set; } = "/Resource/Images/Icons/avatar.png";
        public string test { get; set; } = "";

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}
