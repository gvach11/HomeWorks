using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_11
{
    public class Facade
    {
        Header header = new Header();
        Body body = new Body();
        Footer footer = new Footer();

        public void ReportHTML()
        {
            header.GenerateHeaderHTML();
            body.GenerateBodyHTML();
            footer.GenerateFooterHTML();
        }

        public void ReportPDF()
        {
            header.GenerateHeaderPDF();
            body.GenerateBodyPDF();
            footer.GenerateFooterPDF();
        }

    }


    public class Header
    {
        public void GenerateHeaderHTML()
        {
            Console.WriteLine("<header> My Header </header>");
        }
        public void GenerateHeaderPDF()
        {
            Console.WriteLine("I’m using Facade Pattern");
        }


    }

    public class Body
    {
        public void GenerateBodyHTML()
        {
            Console.WriteLine("<body>");
            Console.WriteLine("Video provides a powerful way to help you prove your point. When you click \n " +
               "Online Video, you can paste in the embed code for the video you want to add.");
            Console.WriteLine("</body>");
        }
        public void GenerateBodyPDF()
        {
            Console.WriteLine("Video provides a powerful way to help you prove your point. When you click \n " +
                "Online Video, you can paste in the embed code for the video you want to add. \n" +
                "You can also type a keyword to search online for the video that best fits your document.");
        }
    }

    public class Footer
    {
        public void GenerateFooterHTML()
        {
            Console.WriteLine("<footer> My Footer </footer> ");
        }
        public void GenerateFooterPDF()
        {
            Console.WriteLine("Page 1");
        }

    }


}
