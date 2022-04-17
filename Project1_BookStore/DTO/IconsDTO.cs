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
        public string close { get; set; } = "/Resource/Images/Icons/close.png";
        public string closePressed { get; set; } = "/Resource/Images/Icons/close-pressed.png";
        public string maximize { get; set; } = "/Resource/Images/Icons/maximize.png";
        public string maximizePressed { get; set; } = "/Resource/Images/Icons/maximize-pressed.png";
        public string minimize { get; set; } = "/Resource/Images/Icons/minimize.png";
        public string minimizePressed { get; set; } = "/Resource/Images/Icons/minimize-pressed.png";
        public string restore { get; set; } = "/Resource/Images/Icons/restore.png";
        public string restorePressed { get; set; } = "/Resource/Images/Icons/restore-pressed.png";
        public string logo { get; set; } = "/Resource/Images/Icons/logo_v2.png";
        public string upload { get; set; } = "/Resource/Images/Icons/upload.png";
        public string uploadPressed { get; set; } = "/Resource/Images/Icons/upload-pressed.png";
        public string modify { get; set; } = "/Resource/Images/Icons/modify.png";
        public string modifyPressed { get; set; } = "/Resource/Images/Icons/modify-pressed.png";
        public string plus { get; set; } = "/Resource/Images/Icons/plus.png";
        public string minus { get; set; } = "/Resource/Images/Icons/minus.png";
        public string arrow_left { get; set; } = "/Resource/Images/Icons/left-arrow.png";
        public string arrow_right { get; set; } = "/Resource/Images/Icons/right-arrow.png";
        public string info { get; set; } = "/Resource/Images/Icons/info.png";
        public string bell { get; set; } = "/Resource/Images/Icons/bell.png";
        public string sign_out { get; set; } = "/Resource/Images/Icons/sign-out.png";
        public string export { get; set; } = "/Resource/Images/Icons/export.png";
        public string avatar { get; set; } = "/Resource/Images/Icons/avatar.png";
        public string boxes { get; set; } = "/Resource/Images/Icons/boxes.png";
        public string boxesPressed { get; set; } = "/Resource/Images/Icons/boxes-pressed.png";
        public string dashboard { get; set; } = "/Resource/Images/Icons/dashboard.png";
        public string dashboardPressed { get; set; } = "/Resource/Images/Icons/dashboard-pressed.png";
        public string delete { get; set; } = "/Resource/Images/Icons/delete.png";
        public string deletePressed { get; set; } = "/Resource/Images/Icons/delete-pressed.png";
        public string order { get; set; } = "/Resource/Images/Icons/order.png";
        public string orderPressed { get; set; } = "/Resource/Images/Icons/order-pressed.png";
        public string promotion { get; set; } = "/Resource/Images/Icons/promotion.png";
        public string promotionPressed { get; set; } = "/Resource/Images/Icons/promotion-pressed.png";
        public string setting { get; set; } = "/Resource/Images/Icons/setting.png";
        public string settingPressed { get; set; } = "/Resource/Images/Icons/setting-pressed.png";
        public string statistics { get; set; } = "/Resource/Images/Icons/statistics.png";
        public string statisticsPressed { get; set; } = "/Resource/Images/Icons/statistics-pressed.png";

        public string test { get; set; } = "";

        public event PropertyChangedEventHandler? PropertyChanged;
    }

}
