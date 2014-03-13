namespace IisExpressWebServer
{
    public class WebApplication
    {
        /// <summary>
        /// The location of the web application.
        /// </summary>
        public IProjectLocation Location { get; private set; }

        /// <summary>
        /// The port number the web application will be deployed to.
        /// </summary>
        public int PortNumber { get; private set; }

        /// <summary>
        /// Create a web application using the given location and port number.
        /// </summary>
        /// <param name="location">The location of the web application</param>
        /// <param name="portNumber">The port number the web application will be deployed to</param>
        public WebApplication(IProjectLocation location, int portNumber)
        {
            Argument.CheckIfNull(location,"IProjectLocation");
            Argument.CheckIntIfNullOrValue(portNumber,1,"PortNumber");
            Location = location;
            PortNumber = portNumber;
        }
    }
}
