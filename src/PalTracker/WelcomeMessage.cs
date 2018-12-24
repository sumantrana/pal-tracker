
namespace PalTracker {

    public class WelcomeMessage {

        public string Message { get; set;}
        public string User { get; set;}

        public WelcomeMessage( string message ){

            Message = message;
            
        }

        public WelcomeMessage( string message, string user ){

            Message = message;
            User = user;
            
        }        

        public WelcomeMessage(){

        }
    }
}