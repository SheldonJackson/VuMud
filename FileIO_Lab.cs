using VuMud.Items;

namespace VuMud {
    public class FileIO_Lab {
        public static void Main() {
            var itemManager = new ItemManagement();
            const string path = "C:\\temp\\testingIn.txt";

            itemManager.ExportWeaponItemsToCsv(path);
        }
    }
}
