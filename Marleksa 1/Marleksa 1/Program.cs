namespace Marleksa_1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AtpazinimasDokumento naujasdokumentas = new AtpazinimasDokumento();
            naujasdokumentas.AtpazinimasDokumentoMetodas(); 
            
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
           // ApplicationConfiguration.Initialize();
           // Application.Run(new Form1());
        }
    }
}