using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ProcessingAndWait.Classes.Helpers
{
    public class TextBoxWriter : TextWriter
    {
    
        private Control _control;
        public TextBoxWriter(Control control)
        {
            _control = control;
        }


        public override void Write(char value)
        {
            _control.Text += value;
        }

        public override void Write(string value)
        {
            _control.Text += value;
        }

        public override Encoding Encoding => Encoding.Unicode;
    }
}