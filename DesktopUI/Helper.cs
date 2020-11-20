using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopUI
{
    static class Helper
    {
        public static void mesaj(string Mesaj)
        {
            MessageBox.Show(Mesaj);
        }
        public static void MesajError(string Mesaj)
        {
            MessageBox.Show(Mesaj,"Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        public static void Hata(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (Exception exception)
            {

                MesajError(exception.Message);
            }
        }
        public static void GelirControl(Gelir gelir)
        {
            if (string.IsNullOrEmpty(gelir.GelirAdi)) throw new Exception("Gelir adını girmediniz.");

            
        }
    }
}
