using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MindmapperCore;

namespace MindmapperGui
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private MainController m_MainController;

        public Window1()
        {
            InitializeComponent();
            m_MainController = new MainController(cvsBoard);
            txtCommand.PreviewKeyDown += new KeyEventHandler(txtCommand_PreviewKeyDown);
        }

        private void txtCommand_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                m_MainController.ExecuteInstruction(txtCommand.GetLineText(txtCommand.LineCount-1));
            }
        }


    }
}
