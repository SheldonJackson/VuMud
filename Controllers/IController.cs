namespace VuMud.Controllers {
    public interface IController
    {
        void HandleResponse(string action, string target);
    }
}
