using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CargaXMLPOS.Resources;

namespace CargaXMLPOS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NotifyIcon _icon = new NotifyIcon();
        private ConfigModel _valores = new ConfigModel();
        public MainWindow()
        {
            InitializeComponent();
            this._icon.Visible = true;
            this._icon.Icon = Resource1.BiohazardICO;
            this._icon.Text = @"XML CARGA POS";
            this._icon.ContextMenu = new System.Windows.Forms.ContextMenu();
            this._icon.ContextMenu.MenuItems.Add("Maximizar Ventana");
            this._icon.ContextMenu.MenuItems.Add("Minimizar Ventana");
            this._icon.ContextMenu.MenuItems.Add("Salir");
            tproceso.Text = "Automatico";


            var iniarchivo = new IniFile("Resources/config.ini");
            _valores.Origen = iniarchivo.Read("origen", "Carpetas");
            _valores.Error = iniarchivo.Read("error", "Carpetas");
            _valores.Backup = iniarchivo.Read("respaldo", "Carpetas");
            _valores.Respuesta = iniarchivo.Read("respuesta", "Carpetas");
            _valores.Intervalo = int.Parse(iniarchivo.Read("minutos", "Intervalo"));
            _valores.Intento = int.Parse(iniarchivo.Read("intento", "Intentos"));

            tintervalo.Text = _valores.Intervalo.ToString() + " minutos";
            xmlorigen.Text = _valores.Origen;
            xmlerror.Text = _valores.Error;
            xmlbackup.Text = _valores.Backup;
            xmlrespuesta.Text = _valores.Respuesta;


        }



        public class ConfigModel
        {
            public string Origen { get; set; }
            public string Error { get; set; }
            public string Backup { get; set; }
            public string Respuesta { get; set; }
            public int Intervalo { get; set; }
            public int Intento { get; set; }
        }
    }
}
