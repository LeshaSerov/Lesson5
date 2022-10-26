// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using Lesson5;

class MyClass
{
    public static void Main(string[] args)
    {
        PhoneBook phoneBook = PhoneBook.getInstance("названиеФайла.txt");
        
        //Проверка на синглетон
        // PhoneBook phoneBook = PhoneBook.getInstance("названиеФайла.txt");
        
        phoneBook.AddAbonent(new Abonent("Vas", "134"));
        //При попытке добавить такой же элемент выкидывает ошибку
        //phoneBook.AddAbonent(new Abonent("Vas", "134"));

        //Про уникальность не было и слова
         phoneBook.AddAbonent(new Abonent("Iv", "134"));
        var ab1 = phoneBook.GetAbonenetByName("Iv");
        Console.WriteLine(ab1.GetName() + ":" + ab1.GetNumberPhone());

        //Соответсвенно выдаст последнего найденного
        var ab2 = phoneBook.GetAbonentByNumber("134");
        Console.WriteLine(ab2.GetName() + ":" + ab2.GetNumberPhone());
        
        //Ну и удалит так же
        phoneBook.RemoveAbonent("134");
        
        //Соотвественно на этот момент останется только первый элемент
        var ab3 = phoneBook.GetAbonenetByName("Vas");  
        phoneBook.RemoveAbonent(ab3);
        
        phoneBook.SaveList("названиеФайла.txt");
    }
}
