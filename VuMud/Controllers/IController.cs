using System;
using System.Security.Cryptography.X509Certificates;

namespace VuMud.Controllers {
    public interface IController
    {
        void DisplayMenu();
        void HandleResponse();
    }
}
